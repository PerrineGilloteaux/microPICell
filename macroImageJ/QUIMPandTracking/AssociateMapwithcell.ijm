run("Close All");
dir=getDirectory("Choose a Directory");
run("Text Image... ", "open="+dir+"experiment_0_motilityMap.maQP");
Speed=getTitle();
run("Text Image... ", "open="+dir+"experiment_0_xMap.maQP");
xcoord=getTitle();
run("Text Image... ", "open="+dir+"experiment_0_yMap.maQP");
ycoord=getTitle();
open(dir+"cropcelltest.tif");
cell=getTitle();
run("Tile");

waitForUser("click ok and move your mouse over one of the motility point");
logOpened = false;

 x2=-1; y2=-1; z2=-1; flags2=-1;


while ( isOpen(Speed)) {
		if (getTitle()!=cell){
          getCursorLoc(x, y, z, flags);
          if (x!=x2 || y!=y2 || z!=z2 || flags!=flags2) {

          print(getTitle()+" " +x+" "+y+" "+z);
          selectWindow(xcoord);
          Xv=getPixel(x, y);
          selectWindow(ycoord);
          Yv=getPixel(x, y);
          selectWindow(cell);
          run("Select None");
          setSlice(y+1);
          makePoint(Xv, Yv);
          startTime = getTime();

          }
          x2=x; y2=y; z2=z; flags2=flags;

          wait(10);
      }
}
