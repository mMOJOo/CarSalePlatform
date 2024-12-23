//////////////////////////////////////////////////////////////////////
/////////       WEB PROGRAMMING HOMEWORK 23.12.2024      /////////////
///       BERKE ŞAHİN B221202053 / SUUDE NAS ÇETİN B221202006      ///
//////////////////////////////////////////////////////////////////////
namespace CarSalePlatform.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; } // The RequestId represents a unique ID or tracking number related to the error.
    // The RequestId value may be empty (string?).

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); // Checks whether the RequestId value is empty or null.
    // If the RequestId is not empty (!string.IsNullOrEmpty(RequestId)) returns true.
    // If the RequestId is empty or null, it returns false.
}
