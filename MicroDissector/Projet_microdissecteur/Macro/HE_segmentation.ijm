//MACRO - IMAGE ANALYSIS - H&E SEGMENTATION

//Function to display coordinates
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
title = getTitle();
selectImage(title);
s = split(title, ".");
str = s[0]+"_roi-";

//Make selection with WEKA and get ROI
run("Colour Deconvolution", "vectors=H&E");
wait(5000);
selectWindow(title+"-(Colour_2)");
run("Trainable Weka Segmentation");
wait(3000); //Wait for WEKA button option loading
selectWindow("Trainable Weka Segmentation v3.2.34");
classifier = getDirectory("home")+"Projet_microdissecteur\\Macro\\Classifiers\\classifier.model"
call("trainableSegmentation.Weka_Segmentation.loadClassifier", classifier);
call("trainableSegmentation.Weka_Segmentation.getResult");

selectWindow("Classified image");
setThreshold(0,0);
run("Convert to Mask");
run("Dilate");
run("Erode");
run("Fill Holes");
run("Analyze Particles...", "size=200-Infinity add");
run("Clear Results");

n = roiManager("count");
for (i=0; i<n; i++){ //For each ROI, list each coordinates with get_coordinates
	name = i+1;
	roiManager("Select", i);
	get_coordinates(name);
}

//Save ROI
fileName = getDirectory("home")+"Projet_microdissecteur\\Coord\\"+s[0]+"_ROI.csv";
saveAs("Results", fileName);

//Close all
close("*");
roiManager("reset");
selectWindow("ROI Manager");
run("Close");