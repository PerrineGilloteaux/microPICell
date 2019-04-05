dir = getDirectory("Choose a Directory ");
list = getFileList(dir);

for (i=0; i<list.length; i++) {
	run("Close All");
        if (endsWith(list[i], ".nd2")){ // maybe not to keep, sarting with openned images?
//STEP 1
// Identify the ISOLATED cells

//Step 0  the image as split channel.
run("Bio-Formats Importer", "open=["+dir+list[i]+"] color_mode=Default display_metadata rois_import=[ROI manager] split_channels view=Hyperstack stack_order=XYCZT");
if (nImages>2){
C2=getTitle();
C1=replace(C2, "C=2", "C=1");
C0=replace(C2, "C=2", "C=0");
selectWindow(C2);
close();
}
else {
C1=getTitle();

C0=replace(C1, "C=1", "C=0");	
}
// prepare image to score positive or negative
selectWindow(C1);
nbslices=nSlices;
while (nSlices>1)
{
	setSlice(2);
	run("Delete Slice");
}
setAutoThreshold("Default dark");
//run("Threshold...");
setAutoThreshold("Default dark stack");
setOption("BlackBackground", false);
run("Convert to Mask", "method=Default background=Dark calculate black");

//Step 2: score it as positive or negative

selectWindow(C0);
waitForUser("Select the cell of interest and press OK");
run("Gaussian Blur...", "sigma=2 stack");
setAutoThreshold("Default dark stack");

setAutoThreshold("Huang dark stack");
run("Convert to Mask", "method=Huang background=Dark calculate black");
selectWindow(C1);
run("Restore Selection");
run("Measure");
positive=getResult("Mean", 0);
run("Clear Results");
selectWindow(C0);
run("Duplicate...", "title=cell duplicate");
run("Close-", "stack"); //remove isolated pixels
waitForUser("check if the mask is ok ottherwise correct it");
saveAs("Tiff", dir+"cropcelltest_segmented.tif");
saveAs("Tiff", dir+"cropcelltest.tif");
run("Close All");
//Step 3 for each cell, perform the analysis (do anayse particle and tracking?)
experimentname=replace(C0, "C=0", "");
// define where to save main configuration file. It will be shared among QuimP modules. 
// Any other file generated by QuimP will be saved in this folder as well 
//qconfOutput = dir+experimentname+".QCONF";
// open segmented image, you can use any other segmentation software to obtain masks 

qconfOutput = "D:\/JeanMerot\/ImagesJean\/test\/experiment.QCONF" ;
// open segmented image, you can use any other segmentation software to obtain masks 
open(dir+'cropcelltest_segmented.tif') ;
// open original image 
open(dir+'cropcelltest.tif') ;
//Frame du flux et separé flux vs pas flux
// 1) perform conversion from mask to QCONF file. This step corresponds to saving segmentation in BOA
run("Generate Qconf", "opts={options:{select_mask:cropcelltest_segmented.tif,select_original:cropcelltest.tif,step:1.0,smoothing:false,clear_nest:true,restore_snake:true},maskFileName:(),paramFile:("+qconfOutput+")}");
 
// 2) run ECMM analysis on configuration file 
run('ECMM Mapping', "opts={paramFile:("+qconfOutput+")}"); 
 
// 3) run ANA analysis, we use only one channel 

selectWindow('cropcelltest.tif'); 
run('ANA', 'opts={plotOutlines:true,fluoResultTable:true,fluoResultTableAppend:false,' + 
     // configure displaying 
      'channel:0, userScale:5.0,' + 
     // set channel and cortex width (in um, pixel size from image will be used) 
      'normalise:true, sampleAtSame:false,' + 
      'clearFlu:false,' + 
      'paramFile:('+qconfOutput+')}'); 
 
// 4) run Q analysis 
run('QuimP Analysis', 'opts={trackColor:Summer,' + 'outlinePlot:Speed,' + 'sumCov:1.0,avgCov:0.0,' + 'mapRes:400,' + 'paramFile:('+qconfOutput+')}'); 
 
// 5) convert data to csv filesand generate coordinates maps 

run("Format converter", "opts={status:[map:ycoords,map:xcoords,map:motility],areMultipleFiles:false,paramFile:("+qconfOutput+")}");
run("Close All");
run("Text Image... ", "open=D:\\JeanMerot\\ImagesJean\\test\\experiment_0_motilityMap.maQP");
 getStatistics(area, mean, min, max, std, histogram);
values = newArray(256);
 value = min;
binWidth = (max-min)/256;
for (i=0; i<256; i++) {
               values[i] = value;
               value += binWidth;
}
waitForUser("attente");
Plot.create("Histogram", "Value", "Count", values, histogram);
run("Text Image... ", "open=D:\\JeanMerot\\ImagesJean\\test\\experiment_0_xMap.maQP");
run("Text Image... ", "open=D:\\JeanMerot\\ImagesJean\\test\\experiment_0_yMap.maQP");
IJ.log("Positive Red? "+positive);
waitForUser("attente");
}

}