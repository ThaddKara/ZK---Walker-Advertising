using System;

namespace ZK___Walker_Advertising.Data.Models;

public class LeadModel
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required int PhoneNumber { get; set; }
    public required int ZipCode { get; set; }
    public required bool EmailConsent { get; set; }
    public string? EmailAddress { get; set; }
}