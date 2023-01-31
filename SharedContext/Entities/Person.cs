﻿using Gunnar.Contexts.SharedContext.Enums;
using Gunnar.Contexts.SharedContext.UseCases.Contracts;
using Gunnar.Contexts.SharedContext.ValueObjects;

namespace Gunnar.Contexts.SharedContext.Entities;

/// <summary>
/// A entity to aggregate Person data
/// </summary>
public class Person : Entity, IAggregateRoot
{
    #region Constructors

    /// <summary>
    /// Create a new instance of Person with default configuration
    /// </summary>
    public Person() => Tracker = new Tracker("Criação do cadastro da pessoa");
    
    /// <summary>
    /// Create a new instance of Person with personalized configuration
    /// </summary>
    /// <param name="address">Person detailed address (value object)</param>
    /// <param name="birthDate">Person birthdate</param>
    /// <param name="citizenship">Person citizenship</param>
    /// <param name="documents">Wait an list of Person Documents</param>
    /// <param name="gender">Person Gender</param>
    /// <param name="name">Person Name (value object)</param>
    /// <param name="obs">Person observations</param>
    /// <param name="phone">Person full phone number (value object)</param>
    /// <param name="photo">Person photo url slug</param>
    /// <exception cref="ArgumentNullException"></exception>
    public Person(
        Address address,
        DateTime? birthDate,
        string? citizenship,
        List<Document>? documents,
        string fatherName,
        EGender gender,
        bool isDeleted,
        string motherName,
        Name name,
        string nationality,
        string? obs,
        Phone? phone,
        string? photo)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
        BirthDate = birthDate;
        Citizenship = citizenship;
        Documents = documents;
        FatherName = fatherName;
        Gender = gender;
        IsDeleted = isDeleted;
        MotherName = motherName;
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Nationality = nationality;
        Obs = obs;
        Phone = phone;
        Photo = photo;
        Tracker = new Tracker("Criação do cadastro da pessoa");
    }

    #endregion

    #region Public Properties

    public Address Address { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public string? Citizenship { get; private set; }
    public List<Document>? Documents { get; private set; }
    public string? FatherName { get; private set; } = string.Empty;
    public EGender Gender { get; private set; }
    public bool IsDeleted { get; set; }
    public string? MotherName { get; private set; } = string.Empty;
    public Name Name { get; private set; }
    public string Nationality { get; set; }
    public string? Obs { get; private set; }
    public Phone? Phone { get; private set; }
    public string? Photo { get; private set; }
    public Tracker Tracker { get; } = null!;
    public int Age { get; set; }

    #endregion

    #region Methods

    public void AddDocuments(List<Document> documents)
        => Documents = documents;

    public void ChangeDocuments(List<Document?> documents)
    {
        try
        {
            Documents = documents;
        }
        catch
        {
            throw new InvalidDataException("Não foi possível salvar os documentos.");
        }
    }
    
    public void ChangeInformation(
        DateTime? birthDate,
        string citizenship,
        string fatherName,
        EGender gender,
        string motherName,
        string nationality,
        string obs)
    {
        BirthDate = birthDate;
        Citizenship = citizenship;
        FatherName = fatherName;
        Gender = gender;
        MotherName = motherName;
        Nationality = nationality;
        Obs = obs;

        Tracker.Update("Informações atualizadas");
    }    
    
    public void ChangeAddress(Address address) => Address = address;    
    public void ChangeName(string firstName, string lastName)
        => Name = new Name(firstName, lastName);

    public void ChangePhone(Phone phone)
    {
        Phone = phone;
        Tracker.Update("Número de telefone modificado.");
    }

    public void ChangePhoto(string path)
        => Photo = path;

    public void Delete()
    {
        IsDeleted = true;
        Tracker.Update("Pessoa excluída.");
    }

    public void GeneratePhoneVerificationCode()
    {
        Phone?.GenerateVerificationCode();
        Tracker.Update("Código de verificação de telefone recriado");
    }
    
    public int GetAge()
    {
        int age = DateTime.UtcNow.Year - BirthDate.Value.Year;
        if (DateTime.UtcNow.DayOfYear < BirthDate.Value.DayOfYear)
            age = age - 1;

        return age;
    }

    public void VerifyPhone(string code)
    {
        Phone?.Verification.Verify(code);
        Tracker.Update("Telefone verificado");
    }

    #endregion
    
    #region Overloads

    public override string ToString() => Name;

    #endregion
}