dat<-read.csv("resultdist_intensity_2.csv",sep=";")
dist<-read.csv("resultdist_distance_2.csv",sep=";")
dat2<-read.csv("resultdist_intensity_22.csv",sep=";")
dist2<-read.csv("resultdist_distance_22.csv",sep=";")
par(mfcol=c(2,4))
plot( dist$Mean.Intensity..ch.0., dat$Mean.Intensity..ch.0.,pch='.')
plot( dist2$Mean.Intensity..ch.0., dat2$Mean.Intensity..ch.0.,pch='.')

plot( dist$Mean.Intensity..ch.0., dat$Mean.Intensity..ch.1.,pch='.')
plot( dist2$Mean.Intensity..ch.0., dat2$Mean.Intensity..ch.1.,pch='.')

plot( dist$Mean.Intensity..ch.0., dat$Mean.Intensity..ch.2.,pch='.')
plot( dist2$Mean.Intensity..ch.0., dat2$Mean.Intensity..ch.2.,pch='.')

plot( dist$Mean.Intensity..ch.0., dat$Mean.Intensity..ch.3.,pch='.')
plot( dist2$Mean.Intensity..ch.0., dat2$Mean.Intensity..ch.3.,pch='.')