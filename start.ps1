Write-Host "Running docker compose up...";
docker compose up 

$url = "http://localhost:4200";
Start-Process $url

#$status = 0;
#
#do
#{
#    try
#    {
#        Write-Host "Run request"
#        # First we create the request.
#        # $Request = [System.Net.WebRequest]::Create('http://localhost:4200')
#        # We then get a response from the site.
#        $response = Invoke-WebRequest -Uri $url
#        # We then get the HTTP code as an integer.
#        $status = [int]$response.StatusCode;
#        Write-Host "StatusCode: $($status)";
#    }
#    catch
#    {
#        $status = [int]$_.Exception.Response.StatusCode;
#        if ($status -eq 0) {
#            Write-Host 'Keine Verbindung möglich';
#        } else {
#            Write-Host "StatusCode: $($status)";
#        }
#    }
#}
#while($status -ne 200)
#
#Write-Host "Application available. Trying to start browser for $($url)";

