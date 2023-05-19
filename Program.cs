// See https://aka.ms/new-console-template for more information
using MixAssessment2;

//CalcEngine.DoVehiclePositionCalculation();

var t = Task.Run(() => CalcEngine.DoVehiclePositionCalculation());
t.Wait();


 