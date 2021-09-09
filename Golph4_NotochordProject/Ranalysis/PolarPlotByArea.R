setwd("C:/Users/perri/Nextcloud/FicheProjets/Paillat_Camus_Golf4")
path="C:/Users/perri/Nextcloud/FicheProjets/Paillat_Camus_Golf4/results"
source("getOrientation.R")
source("spot_byarea_normalized.R")
setwd(path)

x0=0
y0=0
x1=512
y1=0
x2=0
y2=512

dev.new()
#par(mfrow=c(2,3)) 
par(mfrow=c(2,2)) 

#Orientation by area

#orientation_cilia_SC<-getOrientation_frame("result_s15_sclerotome_3.xls","result_s15_sclerotome_3_cilia.xls",x0,y0,x1,y1,x2,y2)
#orientation_golgi_SC<-getOrientation_frame("result_s15_sclerotome_3.xls","result_s15_sclerotome_3_golgi.xls",x0,y0,x1,y1,x2,y2)

orientation_cilia_SC_VB<-getOrientation_frame("result_s15_sclerotome_3.xls","result_s15_sclerotome_3_cilia.xls",x0,y0,x1,y1,x2,y2)
orientation_golgi_SC_VB<-getOrientation_frame("result_s15_sclerotome_3.xls","result_s15_sclerotome_3_golgi.xls",x0,y0,x1,y1,x2,y2)
name="Sclerotome_VB"
filenuclei="result_s15_sclerotome_3.xls"
filespot="result_s15_sclerotome_3_cilia.xls"
plot_normalized(filenuclei,filespot,x0,y0,x1,y1,x2,y2,name,path)

orientation_cilia_SC_IVD<-getOrientation_frame("result_s15_sclerotome_IVD2.xls","result_s15_sclerotome_IVD2_cilia.xls",x0,y0,x1,y1,x2,y2)
orientation_golgi_SC_IVD<-getOrientation_frame("result_s15_sclerotome_IVD2.xls","result_s15_sclerotome_IVD2_golgi.xls",x0,y0,x1,y1,x2,y2)
name="Sclerotome_IVD"
filenuclei="result_s15_sclerotome_IVD2.xls"
filespot="result_s15_sclerotome_IVD2_cilia.xls"
plot_normalized(filenuclei,filespot,x0,y0,x1,y1,x2,y2,name,path)

#orientation_cilia_N<-getOrientation_frame("result_s15_notochord_vb_3.xls","result_s15_notochord_vb_3_cilia.xls",x0,y0,x1,y1,x2,y2)
#orientation_golgi_N<-getOrientation("result_s15_notochord_vb_3.xls","result_s15_notochord_vb_3_golgi.xls",x0,y0,x1,y1,x2,y2)


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
plot_normalized(filenuclei,filespot,x0,y0,x1,y1,x2,y2,name,path)

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
