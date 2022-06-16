# XgApiWrapper
 Sophos XG API Wrapper

# Examples
## Init Controller
```
Connection connection = new Connection("FirewallIP", "UserApiAdmin", "MySecurePassword");
XgController xgController = new XgController(connection);
```

## Get 
`await xgController.GetItemsAsync<IPHost>();`
 
## Set
```
IPHost ipHost = new IPHost("DnsServer", HostType.IP, "192.168.0.1", "255.255.255.0");
await xgController.SetItemAsync<IPHost>(ipHost);
```

## Remove
`await xgController.DeleteItemAsync<IPHost>("DnsServer");`
