
annotationnumber=0;
print("ImageData; annotation; Area Plaque; Area Tissue; Area Doute; Area Other ; Area not classified; PercentPlaqueOverall;PercentPlaqueandDouteoverall;PercentPlaqueOverallsansother;PercentPlaqueandDouteoverallsansother");
//******************PENSE AU FICHIER DE SORTIE !!*******************************//
File file = new File("C:/Users/Axio Imager M2/Documents/MarineCoue/outracine12.csv");
//*********************************************************************************/
file.append("ImageData;annotation; Area Plaque; Area Tissue; Area Doute; Area Other ; Area not classified; PercentPlaqueOverall;PercentPlaqueandDouteoverall;PercentPlaqueOverallsansother;PercentPlaqueandDouteoverallsansother\n");
for (annotation in getAnnotationObjects()) {
annotationnumber=annotationnumber+1;
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
     if (detection.getParent()==annotation){
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
}}
imageData = getCurrentImageData();
def server = getCurrentImageData().getServer();
double pixelWidth = server.getPixelWidthMicrons();
double pixelHeight = server.getPixelHeightMicrons();



Total=(areaPlaque+areaTissue+areadoute+areaOther+areanotclassified);
Totalsansother=(areaPlaque+areaTissue+areadoute+areanotclassified);
pcPlaque=100*areaPlaque/Total;
pcPlaqueetdoute=100*(areaPlaque+areadoute)/Total;
pcPlaquesansother=100*areaPlaque/Totalsansother;
pcPlaqueetdoutesansother=100*(areaPlaque+areadoute)/Totalsansother;




print(""+imageData+";"+annotationnumber+";"+areaPlaque*pixelWidth *pixelHeight +";"+areaTissue*pixelWidth *pixelHeight +";"+areadoute*pixelWidth *pixelHeight +";"+areaOther*pixelWidth *pixelHeight +";"+areanotclassified*pixelWidth *pixelHeight+";" +pcPlaque+";"+pcPlaqueetdoute+";"+pcPlaquesansother+";"+pcPlaqueetdoutesansother);

file.append(""+imageData+";"+annotationnumber+";"+areaPlaque*pixelWidth *pixelHeight +";"+areaTissue*pixelWidth *pixelHeight +";"+areadoute*pixelWidth *pixelHeight +";"+areaOther*pixelWidth *pixelHeight +";"+areanotclassified*pixelWidth *pixelHeight+";" +pcPlaque+";"+pcPlaqueetdoute+";"+pcPlaquesansother+";"+pcPlaqueetdoutesansother+"\n");
}
