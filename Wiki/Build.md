# Build

Static Webs Apps have a unique structure. There are two components for the release environment and three for the development. The build process is a little different than a traditional web app. 
The build process is as follows:
	- Build the Azurite Runner (for dev testing and for the local storage emulator)
	- Build the SWAResume project
	- Build the SWAResumeAPI project

## Azurite Runner

This is a simple console app that will run the Azurite emulator. It is used for local development and testing. It is also used for the local storage emulator. The Azurite Runner is a .NET 6.0 console app.

### Code
```c#
		
        public static void Main(string[] args) {
            var cts = new CancellationTokenSource();
            using (Process process = new Process()) {
                cts.Token.Register(() => process.Kill());
                process.StartInfo.FileName = "azurite.cmd";
                process.StartInfo.Arguments = "--skipApiVersionCheck --location .vstools/azurite/ --debug .vstools/azurite/debug.log";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                StreamReader reader = process.StandardOutput;
                string line;
                while ((line = reader.ReadLine()) != null) {
                    Console.WriteLine(line);
                }
                process.WaitForExit();
            }
        }
```

