dir = getDirectory("Choose a Directory ");
setBatchMode(true);
count = 0;
countFiles(dir);
n = 0;
processFiles(dir);
print("end");
   
function countFiles(dir) {
	list = getFileList(dir);
	for (i=0; i<list.length; i++) {
		if (endsWith(list[i], "/"))
			countFiles(""+dir+list[i]);
		else
			count++;
	}
}


function processFiles(dir) {
	list = getFileList(dir);
	for (i=0; i<list.length; i++) {
		if (matches(list[i], "FITC.*/")){//dossier avec FITC
			path = dir+list[i];
			processFile(path,dir);
		} else if (endsWith(list[i], "/")){
			processFiles(""+dir+list[i]);
		}
	}
}

function processFile(path,dir) {
	listFITCH = getFileList(path);
	cpt=0;
	listFITC=newArray(listFITCH.length);
	for(i=0; i<listFITCH.length; i++){
		if(endsWith(listFITCH[i], ".tif")){
			listFITC[cpt]=listFITCH[i];
			cpt++;
		}
	}
	listFITC=Array.slice(listFITC,0,cpt);
	listDAPI = getFileList(dir+"DAPI");
	
	for(i=0; i<listDAPI.length; i++){
		run("Bio-Formats Importer", "open=["+dir+"DAPI"+File.separator+listDAPI[i]+"] color_mode=Default rois_import=[ROI manager] view=[Standard ImageJ] stack_order=Default");
		open(path+listFITC[i]);
		run("Merge Channels...", "c2=["+listFITC[i]+"] c3=["+listDAPI[i]+"]");
		newName=listFITC[i]+" MERGE";
		saveAs("Tiff", dir+newName);
		close("*");
	}
}  