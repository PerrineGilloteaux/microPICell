### MICRODISSECTEUR AUTOMATISATION ###
# This script is called by CT-REMOTE-FORM to run ImageJ/QuPath/Ilastik script depending on the user analysis objectives.
# It is not supposed to be run manually.

# Imports
import os
import sys
import subprocess
import csv
import fileinput
from datetime import datetime, date

# Run macro depending on informations



# 1st macro
print("Running ImageJ analysis.....")
os.chdir(".\Dependencies\Fiji.app")
script = "..\..\..\Macro\get_ROI_ImageJ.ijm"
##        script = os.path.join(user, "Projet_microdissecteur\Macro\HE_segmentation.ijm")

subprocess.call(["ImageJ-win64.exe", "-macro", script])
print("avantpath")
# Transform ROI
pathROI ="C:\\Users\\paul-gilloteaux-p\\Projet_microdissecteur\\Coord"
print("pathROI:")
print(pathROI)
nameIJ = os.path.join(pathROI, ("acquired_image" + "_ROI.csv"))
print(nameIJ)
##scale = 0.4342553 * 0.001 #1pixel = 0.4342553um, needs to be in mm for TransferShape
##        scale = 0.550582 * 0.001
scale = 0.4275 * 0.001
boundingboxleft = 24.9  # image coords for microdissecteur start at 24.9um (left)
boundingboxtop = 1  # image coords for microdissecteur start at 1um (top)
midX = scale * (1920 / 2)  # Xmid image in um
midY = scale * (1200 / 2)  # Ymid image in um

with fileinput.input(files=nameIJ, inplace=True, mode="r") as f:  # Open csv file and change ROI
    reader = csv.DictReader(f)
    print(";".join(reader.fieldnames))
    for row in reader:
        X = float(row["X"]) * scale + 26.5 - boundingboxleft - midX  # Change X coordinates depending on rescaling (with info[5][0] : X coord of acquired image)
        Y = float(row["Y"]) * scale + 53.2 - boundingboxtop - midY  # Change Y coordinates depending on rescaling (with info[5][1] : Y coord of acquired image)
        row["X"] = (str(X))
        row["Y"] = (str(Y))
        print(";".join([row[' '], row["Coord"], row["X"], row["Y"]]))

sys.exit(0)
