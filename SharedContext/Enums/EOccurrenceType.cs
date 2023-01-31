﻿using System.ComponentModel.DataAnnotations;

namespace Gunnar.Contexts.SharedContext.Enums;

public enum EOccurrenceType : byte
{
    [Display(Name="Ingresso no rol de membros.")]
    MembershipEntry,
    [Display(Name="Desligamento do rol de membros - falecimento.")]
    RemovedFromMembership_Death,
    [Display(Name="Desligamento do rol de membros - mudança.")]
    RemovedFromMembership_ChangeResidence,
    [Display(Name="Desligamento do rol de membros - abondono da comunhão.")]
    RemovedFromMembership_MembershipAbandonment,
    [Display(Name="Desligamento do rol de membros - exclusão.")]
    RemovedFromMembership_Exclusion,
    [Display(Name="Desligamento do rol de membros - a pedido.")]
    RemovedFromMembership_OnDemand,
    [Display(Name="Consagração ao Diaconato.")]
    SetApartAsDiacon,
    [Display(Name="Consagração ao Presbitério.")]
    SetApartAsElder,
    [Display(Name="Consagrado Pastor.")]
    SetApartAsPastor,
    [Display(Name="Consagrado Evangelista.")]
    SetApartAsEvangelist,
    [Display(Name="Casamento.")]
    Wedding
}