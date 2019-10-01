Dialog.create("SVS segmentation");
Dialog.addString("common suffix for Dicom image", "0000");
dir = getDirectory("Choose a Directory to process ");
Dialog.show();

suffix=Dialog.getString();
count = 1;
call("ij.plugin.frame.ThresholdAdjuster.setMode", "Red");
labels= newArray(100);
listFilesandprocess(dir,labels); 
for (i=0;i<count;i++){
setResult("Label", i, labels[i]) ;
}
 updateResults();
saveAs("results", dir+"svs.csv");
function listFilesandprocess(dir,labels) {
     list = getFileList(dir);
     for (i=0; i<list.length; i++) {
        if (endsWith(list[i], "/"))
           listFilesandprocess(""+dir+list[i],labels);
        else {
           
           if (endsWith(list[i], suffix)){
           filename=list[i];
           print(dir + list[i]);
          
           processSVS(filename,labels);
           }
     	}
     }
  }

function processSVS(filename,labels){
  	open(dir+filename);
  	
  	 run("Set Measurements...", "area mean standard modal min perimeter shape integrated median skewness kurtosis redirect="+filename+" decimal=3");
	//change the look up table
	run("mpl-magma");

	run("Duplicate...", "title=mask");
	setAutoThreshold("Mean");
	getThreshold(lower, upper);
	setThreshold(lower, upper*1.1);
	run("Tile");
	run("Synchronize Windows");
	setTool("rectangle");
	
	waitForUser("draw a rectangle around SVS, then click OK");
	selectWindow("mask");
    run("Analyze Particles...", "display add");
   	for(n=0;n<roiManager("count");n++)
    {	
    	labels[count-1]=dir+filename;
    	count++;
    }
  	
 	
    run("Close All");
    if (roiManager("count")>0){
    roiManager("Deselect");
	roiManager("Delete");
    }
  }


