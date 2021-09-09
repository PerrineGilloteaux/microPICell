


#EDIT with Working directory and Result path
Script_Directory<-"C:\Users\paul-gilloteaux-p\Documents\GitHub\ANRCROCOVAL\microPICell\Golph4_NotochordProject\Ranalysis"
ResultPath<-"D:\nextCLOUD\FicheProjets\Paillat_Camus_Golf4\results\"

#Load scripts
setwd(Script_Directory)



# Define Frame of Reference (pixel coordinates)
x0=246
y0=258
x1=455
y1=89
x2=148
y2=130


dev.new()

par(mfrow=c(2,2)) 

#SCLEROTOME_VB
datnuclei_SC_VB<-read_icytable(paste(ResultPath,"result_s15_sclerotome_3.xls", sep="")
datcilia_SC_VB<-read_icytable(paste(ResultPath,"result_s15_sclerotome_3_cilia.xls", sep="")
datgolgi_SC_VB<-read_icytable(paste(ResultPath,"result_s15_sclerotome_3_golgi.xls", sep="")


orientation_cilia_SC_VB<-getOrientation_frame(datnuclei_SC_VB,datcilia_SC_VB,x0,y0,x1,y1,x2,y2)
orientation_golgi_SC_VB<-getOrientation_frame(datnuclei_SC_VB,datgolgi_SC_VB,x0,y0,x1,y1,x2,y2)

plot_orientation_normalized(datnuclei_SC_VB,datcilia_SC_VB,x0,y0,x1,y1,x2,y2,"Sclerotome_VB",Script_Directory)

#SCLEROTOME__IVD
datnuclei_SC_IVD<-read_icytable(paste(ResultPath,"result_s15_sclerotom_IVD2.xls", sep="")
datcilia_SC_IVD<-read_icytable(paste(ResultPath,"result_s15_sclerotome_IVD2_cilia.xls", sep="")
datgolgi_SC_IVD<-read_icytable(paste(ResultPath,"result_s15_sclerotome_IVD2_golgi.xls", sep="")

orientation_cilia_SC_VB<-getOrientation_frame(datnuclei_SC_IVD,datcilia_SC_IVD,x0,y0,x1,y1,x2,y2)
orientation_golgi_SC_VB<-getOrientation_frame(datnuclei_SC_IVD,datgolgi_SC_IVD,x0,y0,x1,y1,x2,y2)


plot_orientation_normalized(datnuclei_SC_IVD,datcilia_SC_IVD,x0,y0,x1,y1,x2,y2,"Sclerotome_IVD",Script_Directory)



"Notochord_VB"
#NOTOCHORD_VB
datnuclei_SC_IVD<-read_icytable(paste(ResultPath,"result_s15_sclerotom_IVD2.xls", sep="")
datcilia_SC_IVD<-read_icytable(paste(ResultPath,"result_s15_sclerotome_IVD2_cilia.xls", sep="")
datgolgi_SC_IVD<-read_icytable(paste(ResultPath,"result_s15_sclerotome_IVD2_golgi.xls", sep="")

orientation_cilia_SC_VB<-getOrientation_frame(datnuclei_SC_IVD,datcilia_SC_IVD,x0,y0,x1,y1,x2,y2)
orientation_golgi_SC_VB<-getOrientation_frame(datnuclei_SC_IVD,datgolgi_SC_IVD,x0,y0,x1,y1,x2,y2)


plot_orientation_normalized(datnuclei_SC_IVD,datcilia_SC_IVD,x0,y0,x1,y1,x2,y2,"Sclerotome_IVD",Script_Directory)


orientation_cilia_N_VB<-getOrientation_frame("result_s15_notochord_vb_3.xls","result_s15_notochord_vb_3_cilia.xls",x0,y0,x1,y1,x2,y2)
orientation_golgi_N_VB<-getOrientation_frame("result_s15_notochord_vb_3.xls","result_s15_notochord_vb_3_golgi.xls",x0,y0,x1,y1,x2,y2)
name="Notochord_VB"
filenuclei="result_s15_notochord_vb_3.xls"
filespot="result_s15_notochord_vb_3_cilia.xls"
plot_normalized(filenuclei,filespot,x0,y0,x1,y1,x2,y2,name,path)


orientation_cilia_N_NP<-getOrientation_frame("result_s15_notochord_np2.xls","result_s15_notochord_np2_cilia.xls",x0,y0,x1,y1,x2,y2)
orientation_golgi_N_NP<-getOrientation_frame("result_s15_notochord_np2.xls","result_s15_notochord_np2_golgi.xls",x0,y0,x1,y1,x2,y2)

name="Notochord_NP"
filenuclei="result_s15_notochord_np2.xls"
filespot="result_s15_notochord_np2_cilia.xls"
plot_normalized(filenuclei,filespot,x0,y0,x1,y1,x2,y2,name,Script_Directory)

library(circular)
nbbins<-12
dev.new()
#par(mfrow=c(2,3)) 
par(mfrow=c(2,2)) 
#rose.diag(pi*orientation_cilia_SC/180, bins=nbbins, col=2, main="Sclerotome")
rose.diag(pi*orientation_cilia_SC_VB/180, bins=nbbins, col=2, main="Sclerotome VB")
rose.diag(pi*orientation_cilia_SC_IVD/180, bins=nbbins, col=2, main="Sclerotome IVD")
#rose.diag(pi*orientation_cilia_N/180, bins=nbbins, col=2, main="Notochord")
rose.diag(pi*orientation_cilia_N_VB/180, bins=nbbins, col=2, main="Notochord VB")
rose.diag(pi*orientation_cilia_N_NP/180, bins=nbbins, col=2, main="Notochord NP")

dev.new()

#par(mfrow=c(2,3)) 
par(mfrow=c(2,2)) 
#rose.diag(pi*orientation_golgi_SC/180, bins=nbbins, col=3, main="Sclerotome")
rose.diag(pi*orientation_golgi_SC_VB/180, bins=nbbins, col=3, main="Sclerotome VB")
rose.diag(pi*orientation_golgi_SC_IVD/180, bins=nbbins, col=3, main="Sclerotome IVD")
#rose.diag(pi*orientation_golgi_N/180, bins=nbbins, col=3, main="Notochord")
rose.diag(pi*orientation_golgi_N_VB/180, bins=nbbins, col=3, main="Notochord VB")
rose.diag(pi*orientation_golgi_N_NP/180, bins=nbbins, col=3, main="Notochord NP")
