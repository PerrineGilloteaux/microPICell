setwd("C:/Users/perri/Nextcloud/FicheProjets/Paillat_Camus_Golf4")

source("getOrientation.R")
setwd("C:/Users/perri/Nextcloud/FicheProjets/Paillat_Camus_Golf4/results")

x0=246
y0=258
x1=343
y1=188
x2=210
y2=216

library(spatstat)
filenuclei="result_s15_sclerotome_3.xls"
filespot="result_s15_sclerotome_3_cilia.xls"

datnuclei <-read.xlsx(filenuclei, 1, header=TRUE,stringsAsFactors=FALSE)
datspot <-read.xlsx(filespot, 1, header=TRUE,stringsAsFactors=FALSE)

datspot$Center.X<-as.numeric(datspot$Center.X)
datspot$Center.Y<-as.numeric(datspot$Center.Y)
datnuclei$Center.X<-as.numeric(datnuclei$Center.X)
datnuclei$Center.Y<-as.numeric(datnuclei$Center.Y)

centernuclei=ppp(datnuclei$Center.X,datnuclei$Center.Y,window=owin(xrange=c(0,512),yrange=c(0,512)))



centerspot=ppp(datspot$Center.X,datspot$Center.Y,window=owin(xrange=c(0,512),yrange=c(0,512)))



library(pracma)
listassociated=nncross(centerspot,centernuclei,what="which",k=1)
plot(centernuclei,pch=".")
arrows(x0=datnuclei$Center.X[listassociated],y0=datnuclei$Center.Y[listassociated],x1=datspot$Center.X,y1=datspot$Center.Y,lwd=1,length=.05,angle=15,col=Col)

orientation<-getOrientation(filenuclei,filespot)
rbPal1 <- colorRampPalette(c('blue','green','yellow','red'))
Col <- rbPal1(360)[as.numeric(cut(orientation,breaks = 360))]

