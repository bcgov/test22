namespace myappwebapi.Infrastructure.HttpClients.Keycloak;

using System.Text.Json;


public static class DIAMClients
{
    public static (string ClientId, string AccessRole) ReactBaseApp => ("REACT-BASEAPP", "react-baseapp");
    public static (string ClientId, string AccessRole) myappwebapi => ("Web-Api", "BASEROLE");
}

/// <summary>
/// This is not the entire Keycloak Client Representation! See https://www.keycloak.org/docs-api/5.0/rest-api/index.html#_clientrepresentation.
/// </summary>
public class Client
{
    /// <summary>
    /// ID referenced in URIs and tokens
    /// </summary>
    public string? ClientId { get; set; }

    /// <summary>
    /// Guid-like unique identifier
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Display name
    /// </summary>
    public string? Name { get; set; }
}

public class Role
{
    public bool? ClientRole { get; set; }
    public bool? Composite { get; set; }
    public string? ContainerId { get; set; }
    public string? Description { get; set; }
    public string? Id { get; set; }
    public string? Name { get; set; }
}
public class Group
{
    public string? Id { get; set; }
    public string? Name { get; set; }
}

/// <summary>
/// This is not the entire Keycloak User Representation! See https://www.keycloak.org/docs-api/5.0/rest-api/index.html#_userrepresentation.
/// This is a sub-set of the properties so we don't accidentally overwrite anything when doing the PUT.
/// </summary>
public class UserRepresentation
{
    public string? Email { get; set; }

    public string? LastName { get; set; }
    public string? FirstName { get; set; }

    public List<FederatedIdentityRepresentation> FederatedIdentities { get; set; } = [];

    public bool Enabled { get; set; } = true; // enabled by default

  //  public List<Group> Groups { get; set; } =  new List<Group>();

    public Dictionary<string, string[]> Attributes { get; set; } = new();


    public void SetPhone(string phone) => this.SetAttribute("phone", phone);

    public void SetPartId(string partId) => this.SetAttribute("partId", partId);


    public void SetPhoneNumber(string phoneNumber) => this.SetAttribute("phoneNumber", phoneNumber);

    public void SetPhoneExtension(string phoneExtension) => this.SetAttribute("phoneExtension", phoneExtension);

    private void SetAttribute(string key, string value) => this.Attributes[key] = [value];
}

public class FederatedIdentityRepresentation
{
    public string IdentityProvider { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

}
