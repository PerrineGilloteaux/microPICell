### MICRODISSECTEUR AUTOMATISATION ###
# This script is called by CT-REMOTE-FORM to run ImageJ/QuPath/Ilastik script depending on the user analysis objectives.
# It is not supposed to be run manually.

#Imports
import os
import sys
import subprocess
import csv
import fileinput
from datetime import datetime, date

#Check if script in called with correct number of parameters
if len(sys.argv) != 4:
    sys.exit("Error: wrong number of parameters.")

try:
    #Open user acquisition file & get informations entered in form as a list
    with open(sys.argv[3], 'r') as f:
        info = [line.rstrip('\n') for line in f] #Remove \n from every line

        dic = info[2].split(",")
        dico ={}
        for item in dic:
            item = item.split(":")
            dico[item[0]] = item[1]
        info[2] = dico #get dictionnary of positions

        info[5] = info[5].split(";") #List of X and Y positions on microdissecteur for the acquired image(2 numbers)
        info[5][0] = (str(info[5][0])).replace(",", ".")
        info[5][1] = (str(info[5][1])).replace(",", ".")

        if info[3] == "Fluorescence":
            info[6] = info[6].split(",") #get list of fluo channels
            info[7] = info[7].split(",") #get list of phenotype of interest

    if info[0] == "Microdissecteur":
        imageTA = sys.argv[1]
        imageM = ""
    else:
        imageTA = sys.argv[1]
        imageM = sys.argv[2]

    slideName = " " + list(info[2].keys())[0]

    base = os.path.basename(sys.argv[1]) #Image name without path
    imageName = os.path.splitext(base)[0] #Image name without extension
    user = os.environ['USERPROFILE']
    pathROI = os.path.join(user, "Projet_microdissecteur\Coord") #Path to results ROI

except:
    sys.exit("Error: couldn't read the info file.")



#Run macro depending on informations
try:

    #ImageJ
    if info[4] == "ImageJ":
        #1st macro
        print("Running ImageJ analysis.....") 
        os.chdir(os.path.join(user, "Projet_microdissecteur\Dependencies\Fiji.app"))
        script = os.path.join(user, "Projet_microdissecteur\Macro\get_ROI_ImageJ.ijm")
        #script = os.path.join(user, "Projet_microdissecteur\Macro\HE_segmentation.ijm")
        subprocess.call(["ImageJ-win64.exe", "-macro", script, sys.argv[1]]) 

        #2nd macro ....


        #Transform ROI
        nameIJ = os.path.join(pathROI, (imageName + "_ROI.csv"))
        scale = 0.4275 * 0.001 #1pixel = 0.4275um, needs to be in mm for TransferShape
        boundingboxleft = 24.9 #image coords for microdissecteur start at 24.9um (left)
        boundingboxtop = 1 #image coords for microdissecteur start at 1um (top)
        midX = scale * (1920/2) #Xmid image in um
        midY = scale * (1200/2) #Ymid image in um

        with fileinput.input(files=nameIJ, inplace= True, mode="r") as f: #Open csv file and change ROI
            reader = csv.DictReader(f)
            print(";".join(reader.fieldnames))
            for row in reader:
                X = int(row["X"]) * scale + float(info[5][0]) - boundingboxleft - midX #Change X coordinates depending on rescaling (with info[5][0] : X coord of acquired image)
                Y = int(row["Y"]) * scale + float(info[5][1]) - boundingboxtop - midY #Change Y coordinates depending on rescaling (with info[5][1] : Y coord of acquired image)
                row["X"] = (str(X))
                row["Y"] = (str(Y))
                print(";".join([row[' '], row["Coord"], row["X"], row["Y"]]))
                
    
    #QuPath ---- PATH NOT UPDATED
    elif info[4] == "QuPath":
        print("Running QuPath analysis.....")

        #Create a new directory for the project
        hour = datetime.now()
        date = date.today()
        dirname = date.strftime("%b-%d-%Y") + "_" + hour.strftime("%H%M%S") + "_" + imageName
        pathDir = os.path.join(r"C:\Users\Marianne\Documents\Stage\Images\images_microdissecteur\Lame", dirname) #path to new directory for the project
        os.mkdir(pathDir)

        #Go to Qupath directory and run macro
        os.chdir(r"C:\\Users\\Marianne\\AppData\\Local\\QuPath-0.2.3\\app") #path to qupath directory
        script = r"C:\\Users\\Marianne\\Documents\\Stage\\Programmation\\Qupath\\seg_test1.groovy" #path to qupath script
        subprocess.call(["java", "-jar", "qupath-0.2.3.jar", "-i", sys.argv[1], "script", script])

        #Transform ROI
        nameQP = os.path.join(pathROI, ("results_ROI.txt"))
        with open(nameQP, "r") as f: #Get QuPath file
            lines = [line.rstrip("\n") for line in f]

        lcoord = [] #List of coordinates
        lROI = [] #List of ROI
        for element in lines:    
            element = element.split(', Point:')
            for item in element :
                item = item.replace("[Point: ", "")
                item = item.replace("]", "")
                item = item.replace(" ", "")  
                lcoord.append(item)
            lROI.append(lcoord) 

        newf = os.path.join(pathROI, (imageName + "_ROI.csv")) #Create new csv file
        with open(newf, "w", newline='') as f:
            writer = csv.writer(f, delimiter=',')
            writer.writerow([' ', 'Coord', 'X', 'Y'])
            n = 1
            for roi in lROI:
                for coord in roi:
                    c = coord.split(",")
                    cX = c[0] + 10 #Change X coordinates depending on rescaling
                    cY = c[1] + 10 #Change Y coordinates depending on rescaling
                    writer.writerow([n, (roi.index(coord)+1), cX, cY])
                n = n + 1

        if os.path.exists(nameQP): #Delete txt file
            os.remove(nameQP)


    #Ilastik --- PATH NOT UPDATED
    elif info[4] == "Ilastik":
        print("Running Ilastik analysis.....")
        os.chdir(r"C:\\Users\\Marianne\Documents\Stage\\Images\\Tests\\pixel_classif_ilastik") #Path to pixel classifier
        fname = os.path.join(pathROI, (imageName + "ilastik.tiff"))
        subprocess.call(["C:\Program Files\ilastik-1.3.3post3\ilastik.exe", "--headless", "--project=test1_mirodissecteur_slide.ilp", sys.argv[1]])

except:
    sys.exit("Error: couldn't run image analysis.")


sys.exit(0)
