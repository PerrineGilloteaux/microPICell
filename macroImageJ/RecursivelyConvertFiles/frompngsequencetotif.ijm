dir = getDirectory("Choose a Directory containaing even in several directory the PNGs");
diroutput = getDirectory("Choose a Directory to save the tif"); 
listFiles(dir); 
setBatchMode(true);
function listFiles(dir) {
	  oldprefix="";
     list = getFileList(dir);
     for (i=0; i<list.length; i++) {
        if (endsWith(list[i], "/"))
           listFiles(""+dir+list[i]);
        else
           {
           	currentfile=list[i];
           	if (endsWith(list[i],".png")){
           	prefix=split(currentfile, "0000");
           		if (prefix[0]!=oldprefix) {
           			print(dir+list[i]);
           			print(prefix[0]);
           			run("Image Sequence...", "open="+dir+list[i]+" file="+prefix[0] + " sort");
					saveAs("Tiff", diroutput+prefix[0]+".tif");
					run("Close All");
           		}
			oldprefix=prefix[0];
           }
          
           }
     }
  }


