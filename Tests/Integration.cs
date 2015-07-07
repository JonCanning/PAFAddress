using Xunit;
using PostcodeAnywhereLookup;

public class Integration{

  Service service;
  public Integration()
  {
    service = new Service("http://192.168.251.199:81/afddata.pce");
  }

  [Fact]
  public void Returns_results_from_postcode(){
    var result = service.Lookup("CB18RW").Result;
    Assert.Equal(26, result.Length);
  }

  [Fact]
  public void Returns_result_from_postcode_and_number(){
    var result = service.Lookup("CB18RW", "14").Result;
        Assert.Equal("14", result[0].Number);
  }
}
