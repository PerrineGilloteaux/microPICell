path=getDirectory("Choose a Directory conatining the nd2 to be processed");//choisis le dossier
list=getFileList(path);//liste des fichiers qui sont dans le dossier
//setBatchMode(true); //empèche l'affichage des images
run("Set Measurements...", "area min area_fraction redirect=None decimal=3");
for(i=0; i<list.length; i++){//passe dans tous les fichier de se dossier //list.length
	if (endsWith(list[i], ".jpg")){//fait la suite que si le fichier est un .nd2
		open(path+list[i]);//ouvre l'image
		rename(list[i]+"startImage");//renome l'image
		run("Colour Deconvolution", "vectors=H&E");//déconvolutionne
		selectWindow("Colour Deconvolution");
		close();
		selectWindow(list[i]+"startImage-(Colour_3)");
		close();
		selectWindow(list[i]+"startImage-(Colour_2)");
		close();
		selectWindow(list[i]+"startImage-(Colour_1)");
		rename(list[i]+"MaskSain");//renome la nouvelle image
		run("8-bit");//transforme l'image en 8-bit
		run("Gaussian Blur...", "sigma=10");//floute
		run("Duplicate...", " ");//duplique l'image Dapi		
		rename(list[i]+"MaskEch");//renome la nouvelle image
		run("Threshold...");  // to open the threshold window if not opened yet 
		waitForUser("Madifier puis appluyer sur Apply dans le threshold pour segmenter l'échantillon puis suir ok dans cette fenêtre"); 
		//setAutoThreshold("Default"); 
		roiManager("reset");
		run("Analyze Particles...", "size=2000000-Infinity show=Masks summarize add");//selectionne l'échantillon
		selectWindow(list[i]+"MaskSain");
		roiManager("Select", 0);//met le contour de l'échantillon sur l'image saine
		run("Threshold...");  // to open the threshold window if not opened yet 
		waitForUser("Madifier puis appluyer sur Apply dans le threshold pour segmenté la fluo puis suir ok dans cette fenêtre"); 
		//setAutoThreshold("Default"); 
		run("Analyze Particles...", "size=00-Infinity show=Nothing summarize");
		save(path+list[i]+'Sain.tif');
		selectWindow(list[i]+"MaskEch");
		save(path+list[i]+'Ech.tif');		
	}
	close("*");//ferme les images
}

saveAs("Results", path+"ResultsAirEchAirSain.xls");//sauvegarde le comptage des maxima de toutes les image analysé
//run("Close");//ferme tout