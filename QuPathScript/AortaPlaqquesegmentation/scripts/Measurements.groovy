PlaqueClass = getPathClass("Plaque");
nPlaque= 0;
nNonPlaque = 0;
TissueClass = getPathClass("Tissue");
nTissue= 0;
nNonTissue = 0;
OtherClass = getPathClass("Other");
nOther= 0;
nNonOther = 0;
douteClass = getPathClass("doute");
ndoute= 0;
nNondoute = 0;
areaPlaque =0;
areaTissue =0;
areadoute=0;
areaOther=0;
areanotclassified=0;

for (detection in getDetectionObjects()) {
     roi = detection.getROI();
     pathClass = detection.getPathClass();
    
    if (PlaqueClass.isAncestorOf(pathClass)){
      nPlaque++;
      areaPlaque +=roi.getArea();
      }
    else if (TissueClass.isAncestorOf(pathClass)){
          nTissue++;
          areaTissue +=roi.getArea();
          }
        else if (douteClass.isAncestorOf(pathClass)){
              ndoute++;
              areadoute +=roi.getArea();
              }
                else if (OtherClass.isAncestorOf(pathClass)){
                  nOther++;
                  areaOther +=roi.getArea();
              }
              else
    
                {
              nNonPlaque++;
              areanotclassified +=roi.getArea();
              }
}
imageData = getCurrentImageData()
def server = getCurrentImageData().getServer()
double pixelWidth = server.getPixelWidthMicrons()
double pixelHeight = server.getPixelHeightMicrons()


print imageData
print("Area Plaque; Area Tissue; Area Doute; Area Other ; Area not classified");
print(""+areaPlaque+";"+areaTissue+";"+areadoute+";"+areaOther+";"+areanotclassified);
print(""+areaPlaque*pixelWidth *pixelHeight +";"+areaTissue*pixelWidth *pixelHeight +";"+areadoute*pixelWidth *pixelHeight +";"+areaOther*pixelWidth *pixelHeight +";"+areanotclassified*pixelWidth *pixelHeight );
Total=(areaPlaque+areaTissue+areadoute+areaOther+areanotclassified)*pixelWidth *pixelHeight ;
print("Total surface of aorte in um2: "+Total);
print("Number of Plaque detections: " + nPlaque);

nNonPlaque=nTissue+ndoute+nOther+nNonPlaque;
percentagePlaque = nPlaque / (nPlaque+ nNonPlaque) * 100;
print("Percentage of Plaque detections: " + percentagePlaque);
areanonPlaque=areaTissue+areaOther+areanotclassified;
percentageAreaPlaque = areaPlaque / (areaPlaque + areanonPlaque+areadoute ) * 100;
print("Percentage of Area of Plaque: " + percentageAreaPlaque);
percentageAreaPlaque = (areaPlaque+areadoute) / (areaPlaque + areanonPlaque+areadoute ) * 100;
print("Percentage of Area of Plaque+doute: " + percentageAreaPlaque);
