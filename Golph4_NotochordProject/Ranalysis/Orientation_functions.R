#getOrientation:
#Input: datnuclei, as read from  Icy formatted excel file with nuclei using read_icytable
#Input: datspot as read Icy formatted excel file with spots (independantly)
#Output: Orientation (one line per spot)
getOrientation<-function(datnuclei, datspot){
	

	datspot$Center.X<-as.numeric(datspot$Center.X)
	datspot$Center.Y<-as.numeric(datspot$Center.Y)
	datnuclei$Center.X<-as.numeric(datnuclei$Center.X)
	datnuclei$Center.Y<-as.numeric(datnuclei$Center.Y)



	centerspot=ppp(datspot$Center.X,datspot$Center.Y,window=owin(xrange=c(0,512),yrange=c(0,512)))
	centernuclei=ppp(datnuclei$Center.X,datnuclei$Center.Y,window=owin(xrange=c(0,512),yrange=c(0,512)))
	library(pracma)
	listassociated=nncross(centerspot,centernuclei,what="which",k=1)
	orientation=90+(180/pi*atan((datspot$Center.X-datnuclei$Center.X[listassociated])/(datspot$Center.Y-datnuclei$Center.Y[listassociated])))
	orientation=(sign(datspot$Center.X-datnuclei$Center.X[listassociated])*orientation)+180
	return(orientation)
}

#getOrientation_frame:
#Input: datnuclei Icy formatted excel file with nuclei
#Input: datspot Icy formatted excel file with spots (independantly)
#Input:X0,X1,Y1 (x,y) coordinates of the local referentiel (will define normalized coordinate system)
#Output: Normalized Orientation (one line per spot) in Frame coordiante system
getOrientation_frame<-function(datnuclei, datspot,x0,y0,x1,y1,x2,y2){
	library(vec2dtransf)
	cp<-data.frame(xs=c(x0,x1,x2),ys=c(y0,y1,y2),xt=c(0,1,0),yt=c(0,0,1))
	transfo=AffineTransformation(controlPoints=cp)


	xynuclei<-cbind(datnuclei$Center.X,datnuclei$Center.Y)
	xyspots<-cbind(datspot$Center.X,datspot$Center.Y)

	Snuclei<-SpatialPoints(xynuclei)
	Sspots<-SpatialPoints(xyspots)
	calculateParameters(transfo)

	nuclei_t <- applyTransformation(transfo,Snuclei)
	Sspots_t <- applyTransformation(transfo,Sspots)
	cn<-coordinates(Snuclei_t)
	cs<-coordinates(Sspots_t) 

	centerspot=ppp(cs[,1],cs[,2],window=owin(xrange=c(-5,5),yrange=c(-5,5)))
	centernuclei=ppp(cn[,1],cn[,2],window=owin(xrange=c(-5,5),yrange=c(-5,5)))
	library(pracma)
	listassociated=nncross(centerspot,centernuclei,what="which",k=1)
	orientation=90+(180/pi*atan((cs[,1]-cn[listassociated,1])/(cs[,2]-cn[listassociated,2])))
	orientation=(sign(cs[,1]-cn[listassociated,1])*orientation)+180
	return(orientation)
}

