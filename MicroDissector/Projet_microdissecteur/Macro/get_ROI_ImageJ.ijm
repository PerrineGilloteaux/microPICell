//MACRO - TEST ANALYSE D'IMAGE 

//Function to get results of each ROI selection
function get_coordinates(name){
	nr = nResults;
	Roi.getCoordinates(x, y);
  	for (i=0; i<x.length; i++){
		setResult("Coord", i+nr, name);
		setResult("X", i+nr, x[i]);
		setResult("Y", i+nr, y[i]);
	}
}

//Get argument (image path)
path = getArgument();

//Open image to analyse 
open(path);
title = getTitle()
selectWindow(title);
s = split(title, ".");
str = s[0]+"_roi-";

//Make selection and get ROI
//makeOval(334, 586, 528, 434);
setTool("freehand");
waitForUser("Choose the region to analyse and press OK.")
roiManager("add");

//Get & save results in .csv file named after the image
n = roiManager("count");
for (i=0; i<n; i++){ //For each ROI, list each coordinates with get_coordinates
	name = i+1;
	roiManager("Select", i);
	get_coordinates(name);
}
fileName = getDirectory("home")+"Projet_microdissecteur\\Coord\\"+s[0]+"_ROI.csv";
saveAs("Results", fileName);

//Close all
close("*");
roiManager("reset");
selectWindow("ROI Manager");
run("Close");