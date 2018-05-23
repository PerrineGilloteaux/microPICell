   dir = getDirectory("Choose a Directory ");//choisis le dossier principal	
   setBatchMode(true);//ne pas afficher les images
   //count = 0;
   //countFiles(dir);//compte le nombre de fichier dans tous les sous dossier
   //n = 0;
   processFiles(dir);//effectue le processus
   
   print("end");



   // passe dans tous les sous dossier et compte les fichier
   function countFiles(dir) { 
      list = getFileList(dir);
      for (i=0; i<list.length; i++) {
          if (endsWith(list[i], "/"))
              countFiles(""+dir+list[i]);
          else
              count++;
      }
  }


	//passe dans les sous dossiers et s'arrète sur les FITC
   function processFiles(dir) {
      list = getFileList(dir);
      for (i=0; i<list.length; i++) {
          if (matches(list[i], "FITC.*/")){//dans dossier avec FITC
             path = dir+list[i];
             liste = getFileList(path);
             contrasted(liste,path);//change le contraste
			 processMerge(path,dir);//fait les merges
             }
          else if (endsWith(list[i], "/")){//dans les autres dossier
             processFiles(""+dir+list[i]);
          }
      }
  }


//change le contraste et met en vert
function contrasted(lister,path) {
  	maxi=0;
  	cpt=0;
	mini=newArray(lister.length);//tableau pour enregistrer le min de toutes les images
	for (i=0; i<lister.length; i++) {//pass dans chaque fichier
		if(endsWith(lister[i], ".czi")){//dans ceux finissant par czi
			id=path+lister[i];
			run("Bio-Formats Importer", "open=["+id+"] color_mode=Default rois_import=[ROI manager] view=[Standard ImageJ] stack_order=Default");//ouvre l'image
			rename("stae"+cpt);
			selectWindow("stae"+cpt);
			run("Set Measurements...", "mean standard modal min median limit redirect=None decimal=3");
			run("Measure");
			moy=getResult("Mean", cpt );//récupère la moyenne de l'image
			std=getResult("StdDev", cpt );
			mini[cpt]=getResult("Min", cpt );//enregistre le min dan sun tableau à la bonne place
			if(maxi<moy+(4*std)){//si max plus grand, écrase le précédent
				maxi=moy+(4*std);//je trouvais que ca crachais beaucoup
			}
			cpt++;
		}
	}
	cpt=0;
	for (i=0; i<lister.length; i++) {//pass dans chaque fichier
		if(endsWith(lister[i], ".czi")){//dans ceux finissant par czi
		selectWindow("stae"+cpt);
		run("Duplicate...", " ");
		setMinAndMax(mini[cpt],maxi);//change le min suivant le tableau des min enregistrer et le max avec le plus grand trouvé
		run("Apply LUT");//applique le changement de min et max
		run("Green");//met en vert
		run("8-bit");
		saveAs("Tiff",path+lister[i]+"contrasted");
		close();
		selectWindow("stae"+cpt);
		close();
		cpt++;
		}
	}	
}


//crée merge entre FITC et DAPI
//on est dans le dossier FITC
function processMerge(path,dir) {
	listFITCH = getFileList(path);//fait la liste des fichier
	cpt=0;
	listFITC=newArray(listFITCH.length);//cree un nouvelle list pour enregistrer que celle en tif
	for(i=0; i<listFITCH.length; i++){//pass dans le liste des fichier
		if(endsWith(listFITCH[i], ".tif")){//enregistre dans la nouvelleliste que ceux .tif
			listFITC[cpt]=listFITCH[i];
			cpt++;
		}
	}
	listFITC=Array.slice(listFITC,0,cpt);//supprime case vide de la liste
	listDAPI = getFileList(dir+"DAPI");//liste des fichier dans le dossier DAPI a coté de FITC
	
	for(i=0; i<listDAPI.length; i++){//parcours tous les fichier du dossier DAPI
		run("Bio-Formats Importer", "open=["+dir+"DAPI"+File.separator+listDAPI[i]+"] color_mode=Default rois_import=[ROI manager] view=[Standard ImageJ] stack_order=Default");
		open(path+listFITC[i]);// ouvre les 2 image à merger
		run("Merge Channels...", "c2=["+listFITC[i]+"] c3=["+listDAPI[i]+"]");//merge. change le c2 c3 pour avoir d'autres couleurs
		newName=listFITC[i]+" MERGE";//nouveau nom de fichier
		saveAs("Tiff", dir+newName);//sauvegarde
		close("*");
	}
}  