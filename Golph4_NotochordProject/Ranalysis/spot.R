setwd("C:/Users/perri/Nextcloud/FicheProjets/Paillat_Camus_Golf4/results")

library(spatstat)
datnuclei <-read.csv("result_s15_2_dil3.csv", sep=";")
datspot <-read.csv("result-2_spot.csv", sep=";")

#datnuclei <-read.csv("result_s18_22_dil3.csv", sep=";")
#datspot <-read.csv("result-22_spot.csv", sep=";")


centerspot=ppp(datspot$Center.X,datspot$Center.Y,window=owin(xrange=c(0,512),yrange=c(0,512)))



centernuclei=ppp(datnuclei$Center.X,datnuclei$Center.Y,window=owin(xrange=c(0,512),yrange=c(0,512)))
library(pracma)
listassociated=nncross(centerspot,centernuclei,what="which",k=1)
plot(centernuclei,pch=".")
rbPal1 <- colorRampPalette(c('blue','green','yellow','red'))
orientation=90+(180/pi*atan((datspot$Center.X-datnuclei$Center.X[listassociated])/(datspot$Center.Y-datnuclei$Center.Y[listassociated])))
orientation=(sign(datspot$Center.X-datnuclei$Center.X[listassociated])*orientation)+180
Col <- rbPal1(360)[as.numeric(cut(orientation,breaks = 360))]

arrows(x0=datnuclei$Center.X[listassociated],y0=datnuclei$Center.Y[listassociated],x1=datspot$Center.X,y1=datspot$Center.Y,lwd=1,length=.05,angle=15,col=Col)
