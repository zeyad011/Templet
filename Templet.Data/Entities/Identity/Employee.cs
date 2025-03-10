/*************************
 * 
 * AGECS CONFIDENTIAL
 * __________
 * 
 *  [2016] - [2025] AGECS For Engineering and Technological Consultancy and Services
 *  All Rights Reserved.
 * 
 * NOTICE:  All information contained herein is, and remains
 * the property of AGECS For Engineering and Technological Consultancy 
 * and Services and its suppliers, if any. The intellectual property and technical 
 * concepts contained herein are proprietary to Dr. Ihab El Aghoury and are
 * copyrighted to AGECS For Engineering and Technological Consultancy and Services
 * and its suppliers and may be covered by Canadian, Egyptian and Foreign Patents,
 * and are protected by trade secret or copyright law.
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from AGECS For Engineering and Technological Consultancy and Services.
 */


namespace Templet.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class Employee : IdentityUser
{

    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string Password { get; set; }

}