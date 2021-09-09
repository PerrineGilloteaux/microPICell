plot_normalized<-function(filenuclei,filespot,x0,y0,x1,y1,x2,y2,name,path){
library("xlsx")
setwd("C:/Users/perri/Nextcloud/FicheProjets/Paillat_Camus_Golf4")

source("getOrientation.R")
setwd(path)


library(spatstat)

datnuclei <-read.xlsx(filenuclei, 1, header=TRUE,stringsAsFactors=FALSE)
datspot <-read.xlsx(filespot, 1, header=TRUE,stringsAsFactors=FALSE)

datspot$Center.X<-as.numeric(datspot$Center.X)
datspot$Center.Y<-as.numeric(datspot$Center.Y)
datnuclei$Center.X<-as.numeric(datnuclei$Center.X)
datnuclei$Center.Y<-as.numeric(datnuclei$Center.Y)

xynuclei<-cbind(datnuclei$Center.X,datnuclei$Center.Y)
xyspots<-cbind(datspot$Center.X,datspot$Center.Y)

Snuclei<-SpatialPoints(xynuclei)
Sspots<-SpatialPoints(xyspots)

cp<-data.frame(xs=c(x0,x1,x2),ys=c(y0,y1,y2),xt=c(0,1,0),yt=c(0,0,1))

transfo=AffineTransformation(controlPoints=cp)

calculateParameters(transfo)

Snuclei_t <- applyTransformation(transfo,Snuclei)
Sspots_t <- applyTransformation(transfo,Sspots)
cn<-coordinates(Snuclei_t)
cs<-coordinates(Sspots_t) 

centerspot=ppp(cs[,1],cs[,2],window=owin(xrange=c(-5,5),yrange=c(-5,5)))
centernuclei=ppp(cn[,1],cn[,2],window=owin(xrange=c(-5,5),yrange=c(-5,5)))


library(pracma)
listassociated=nncross(centerspot,centernuclei,what="which",k=1)
plot(centernuclei,pch=".", main=name, xlim = c(-1, 1),ylim = c(-1, 1))
orientation<-getOrientation_frame(filenuclei,filespot,x0,y0,x1,y1,x2,y2)
rbPal1 <- colorRampPalette(c('blue','green','yellow','red'))
Col <- rbPal1(360)[as.numeric(cut(orientation,breaks = 360))]
arrows(x0=cn[listassociated,1],y0=cn[listassociated,2],x1=cs[,1],y1=cs[,2],lwd=1,length=.05,angle=15,col=Col)
#axis(1)
#axis(2)

}

