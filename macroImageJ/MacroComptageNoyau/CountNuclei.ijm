Id=getImageID();
run("Duplicate...", " ");
setAutoThreshold("Huang dark");
run("Convert to Mask");
run("Fit Circle to Image", "threshold=253.02");
selectImage(Id);
run("Duplicate...", " ");
run("Restore Selection");
run("Gaussian Blur...", "sigma=3 scaled");
run("Find Maxima...", "prominence=100 exclude output=[Count]");
run("Find Maxima...", "prominence=100 exclude output=[Point Selection]");

selectImage(Id);
run("Restore Selection");
