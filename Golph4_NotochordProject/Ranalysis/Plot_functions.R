#plot_orientation_normalized
#Input: datnuclei, as read from  Icy formatted excel file with nuclei using read.xlsx(filenuclei, 1, header=TRUE,stringsAsFactors=FALSE)
#Input: datspot, as read from Icy formatted excel file with spots  (independantly)
#Input:X0,X1,Y1 (x,y) coordinates of the local referentiel (will define normalized coordinate system)
#Input name: Legend (typically ROI analyzed)
#Input path: path where Orientation_functionR is saved
#Output: None, do plot arrows from spot to nuclei centers in normalized frame. 

plot_orientation_normalized<-function(datnuclei,datspot,x0,y0,x1,y1,x2,y2,name,path){
	setwd(path)
	source("Orientation_functions.R")
	
	library(spatstat)

	xynuclei<-cbind(datnuclei$Center.X,datnuclei$Center.Y)
	xyspots<-cbind(datspot$Center.X,datspot$Center.Y)

	Snuclei<-SpatialPoints(xynuclei)
	Sspots<-SpatialPoints(xyspots)

	cp<-data.frame(xs=c(x0,x1,x2),ys=c(y0,y1,y2),xt=c(0,1,0),yt=c(0,0,1))

	transfo=AffineTransformation(controlPoints=cp) #from spatstat library

	calculateParameters(transfo) #from spatstat library


	Snuclei_t <- applyTransformation(transfo,Snuclei)#from spatstat library

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


}

