// les variables à remplir
listgy=newArray(0,2,4,8,10,15);
//listmc=newArray(0750,0750,01500,01500,03000,03000,15750,15750,151500,151500,153000,153000);
nbSerie=48;
cellname=newArray("PC3","U251c");//newArray("U251","PC3");
puitChangeCell=25;//NaN pour rien, sinon la serie a partir duquel changer de nom
position=4; //nombre de position, p1, p2



setBatchMode(true); 
path=getDirectory("Choose a Directory conatining the nd2 to be processed");
list=getFileList(path); 
for (i=0; i<list.length; i++) {
	if (endsWith(list[i], ".nd2")){
		print("analyse de : "+list[i]);
		run("Bio-Formats Importer", "open=["+path+list[i]+"] autoscale color_mode=Default rois_import=[ROI manager] view=[Standard ImageJ] stack_order=Default series_1");
		rename("startImage");
		nbChannels=parseInt(getInfo("SizeC"));
		nbTime=parseInt(getInfo("SizeT"));
		nbPlanes=parseInt(getInfo("SizeZ"));
		close();
		cpt=0;
		changeCell=0;
		newname=newArray(nbSerie);
		for (iSerie=1;iSerie<=nbSerie;iSerie++){
			if(isNaN(puitChangeCell)){}else{
				if (iSerie==puitChangeCell){
				changeCell++;
				cpt=0;
				}
			}
			posi=iSerie%position;
			if (posi==0){
				posi=position;
			}
			newname[iSerie-1]=list[i]+"_"+cellname[changeCell]+"_"+listgy[cpt]+"Gy_p"+posi+".tif";
			//newname=list[i]+"_"+cellname[changeCell]+"_"+listgy[cpt]+"Gy_MC"+listmc[cpt]+"_p"+posi+".tif";
			newImage("HyperStack", "8-bit color-mode label", 512, 512, nbChannels, nbFocalPlanes, nbTime);
			setSlice(2);
			run("Grays");
			saveAs("Tiff",path+newname[iSerie-1]);
			close();
			if(iSerie%position==0){
				cpt++;
			}
		}
		
		compt=newArray(nbSerie);
		for(iSerie=0;iSerie<=nbSerie-1;iSerie++){
			compt[iSerie]=1;
		}
		for (iSerie=1;iSerie<=nbSerie;iSerie++){
			if(isOpen(path+list[i])){}else{
				print("Série en cours de réorganisation :"+ iSerie);
				run("Bio-Formats Importer", "open=["+path+list[i]+"] autoscale color_mode=Default rois_import=[ROI manager] view=[Standard ImageJ] stack_order=Default series_"+(iSerie));
				rename("startImage");
				run("8-bit");
				run("Size...", "width=512 height=512 constrain average interpolation=Bilinear");
			}
			for (iHS=1;iHS<=nbSerie;iHS++){
				iHSs=iHS+((iSerie-1)*(nbTime%nbSerie))-(nbSerie*floor((iHS+((iSerie-1)*(nbTime%nbSerie)))/nbSerie));
				if (iHSs==0){iHSs=48;}
				//print(iHSs+" : "+newname[iHSs-1]);
				open(path+newname[iHSs-1]);
				for(iChannels=0;iChannels<=nbChannels-1;iChannels++){
					comptFor=0;	
					for(iTime=0;iTime<=nbTime*2-1;iTime+=nbSerie*2){
						if(iTime+iChannels+(iHS*2)-1<(nbTime*2)-1){
//print("serie : "+iSerie+" Channel : "+iChannels+" temps : "+iTime+" image copier : "+(iTime+iChannels+(iHS*2)-1)+" et collée en : "+(compt[iHSs-1]+iChannels+(2*comptFor)));
							selectWindow("startImage");
							setSlice(iTime+iChannels+(iHS*2)-1);
							run("Copy");
							selectWindow(newname[iHSs-1]);
							setSlice(compt[iHSs-1]+iChannels+(2*comptFor));
							run("Paste");
							comptFor++;
						}
					}	
				}
				compt[(iHSs-1)]=compt[(iHSs-1)]+(comptFor*2);
				run("Save");
				close();
			}
			selectWindow("startImage");
			close();
		}
	}
	print("end");
}
