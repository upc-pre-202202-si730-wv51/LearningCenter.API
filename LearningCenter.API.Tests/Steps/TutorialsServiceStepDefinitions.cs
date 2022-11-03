using System.Net;
using System.Net.Mime;
using System.Text;
using LearningCenter.API.Learning.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace LearningCenter.API.Tests.Steps;

[Binding]
public class TutorialsServiceStepDefinitions : WebApplicationFactory<Program>
{
    private readonly WebApplicationFactory<Program> _factory;

    public TutorialsServiceStepDefinitions(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    
    private Task<HttpResponseMessage> Response { get; set; }

    [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/tutorials is available")]
    public void GivenTheEndpointHttpsLocalhostApiVTutorialsIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"http://localhost:{port}/api/v{version}/tutorials");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { BaseAddress = BaseUri });
    }

    [When(@"a Post Request is sent")]
    public void WhenAPostRequestIsSent(Table saveTutorialResource)
    {
        var resource = saveTutorialResource.CreateSet<SaveTutorialResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }

    [Then(@"A Response is received with Status (.*)")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
        
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }
}