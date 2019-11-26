update Patient set [PatientPhoto] =
(select MyImage.* from Openrowset(Bulk 'C:\Users\Aydar\Documents\GitHub\Healthcare-System\Healthcare_Systemnow\Healthcare_Systemnow\Healthcare_System\bin\Debug\Images\waylon.png', Single_Blob) MyImage)
where PatientID = 1


