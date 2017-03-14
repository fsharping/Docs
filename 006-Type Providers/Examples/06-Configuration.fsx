#r "packages/FSharp.Configuration/lib/net40/FSharp.Configuration.dll"

open FSharp.Configuration

// open App.config
type Settings = AppSettings<"app.config">
Settings.TestTimeSpan


// open Resx files
type Resx = ResXProvider<"MyResource.resx">

Resx.MyResource.Name |> printfn "Name is %s"
Resx.MyResource.Surname |> printfn "Surname is %s"

// open Yaml files
type DockerCloud = YamlConfig<"docker-cloud.yml">
let docker = DockerCloud()
docker.web.image |> printfn "Image is %s"

// Even INI files are supported (but who cares :))
