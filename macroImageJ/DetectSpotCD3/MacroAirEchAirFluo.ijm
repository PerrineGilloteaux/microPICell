path=getDirectory("Choose a Directory conatining the nd2 to be processed");//choisis le dossier
list=getFileList(path);//liste des fichiers qui sont dans le dossier
setBatchMode(true); //empèche l'affichage des images
run("Set Measurements...", "area area_fraction redirect=None decimal=3");
for(i=0; i<list.length; i++){//passe dans tous les fichier de se dossier
	if (endsWith(list[i], ".nd2")){//fait la suite que si le fichier est un .nd2
		run("Bio-Formats Importer", "open=["+path+list[i]+"] autoscale color_mode=Default rois_import=[ROI manager] view=[Standard ImageJ] stack_order=Default");//ouvre l'image
		rename("startImage");//renome l'image
		nbChannels=parseInt(getInfo("SizeC"));//compte le nombre de channels
		run("8-bit");//transforme l'image en 8-bit
		run("Duplicate...", " ");//duplique l'image Dapi
		rename("DuplicMask");//renome la nouvelle image
		run("Threshold...");  // to open the threshold window if not opened yet 
		waitForUser("Madifier puis appluyer sur Apply dans le threshold pour segmenter l'échantillon puis suir ok dans cette fenêtre"); 
		//run("Convert to Mask", "method=IsoData background=Dark calculate");//converti en binaire (que noir et blanc)
		run("Measure");//mesure ce qui est noir donc echantillon
		run("Threshold...");  // to open the threshold window if not opened yet 
		waitForUser("Madifier puis appluyer sur Apply dans le threshold pour segmenté la fluo puis suir ok dans cette fenêtre"); 
		//run("Convert to Mask", "method=yen background=Dark calculate");//converti en binaire (que noir et blanc)
		run("Measure");//mesure ce qui est noir donc les macrophages
	}
	close("*");//ferme les images
}

saveAs("Results", path+"ResultsAirEchAirFluo.xls");//sauvegarde le comptage des maxima de toutes les image analysé
//run("Close");//ferme tout