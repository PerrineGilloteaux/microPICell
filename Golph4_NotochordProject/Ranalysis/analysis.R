setwd("C:/Users/perri/Nextcloud/FicheProjets/Paillat_Camus_Golf4/results")

#dat <-read.csv("result22_slice15.csv", sep=";")
dat <-read.csv("result_s15_2_dil3.csv", sep=";")
x0=222
y0=270
x1=304
y1=207
x2=211
y2=240
cp<-data.frame(xs=c(x0,x1,x2),ys=c(y0,y1,y2),xt=c(0,1,0),yt=c(0,0,1))

#dat <-read.csv("result_true22.csv", sep=";")
#dat<-read.csv("result_s18_22_dil3.csv",sep=";")
#cp<-data.frame(xs=c(144,224,140),ys=c(245,247,215),xt=c(0,1,0),yt=c(0,0,1))

rbPal1 <- colorRampPalette(c('white','red'))
rbPal2 <- colorRampPalette(c('white','green'))
rbPal3 <- colorRampPalette(c('white','magenta'))
rbPal0 <- colorRampPalette(c('white','blue'))

dat$Col1 <- rbPal1(100)[as.numeric(cut(dat$Mean.Intensity..ch.1,breaks = 100))]
dat$Col2 <- rbPal2(100)[as.numeric(cut(dat$Mean.Intensity..ch.2,breaks = 100))]
dat$Col3 <- rbPal3(100)[as.numeric(cut(dat$Mean.Intensity..ch.3,breaks = 100))]
dat$Col0 <- rbPal0(100)[as.numeric(cut(dat$Mean.Intensity..ch.0,breaks = 100))]
 library(vec2dtransf)

transfo=AffineTransformation(controlPoints=cp)

xy<-cbind(dat$Center.X,dat$Center.Y)
S<-SpatialPoints(xy)
calculateParameters(transfo)
par(mfcol=c(2,5))

plot(S,col=dat$Col1,pch=20)
arrows(x0=x0,y0=y0,x1=x1,y1=y1,length=0.05,lwd=2,angle=25,col='gray30')
arrows(x0=x0,y0=y0,x1=x2,y1=y2,length=0.05,lwd=2,angle=25,col='gray10')


plot(applyTransformation(transfo,S),col=dat$Col1,pch=20)
arrows(x0=0,y0=0,x1=1,y1=0,length=0.05,lwd=1,angle=25,col='gray30')
arrows(x0=0,y0=0,x1=0,y1=1,length=0.05,lwd=1,angle=25,col='gray10')
plot(S,col=dat$Col2,pch=20)
plot(applyTransformation(transfo,S),col=dat$Col2,pch=20)
plot(S,col=dat$Col3,pch=20)
plot(applyTransformation(transfo,S),col=dat$Col3,pch=20)
plot(S,col=dat$Col0,pch=20)
plot(applyTransformation(transfo,S),col=dat$Col0,pch=20)
plot(S,pch=20)
axis(1)
axis(2)
plot(applyTransformation(transfo,S),pch=20)
axis(1)
axis(2)

