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


using Templet.Data.Entities.Identity;
namespace Templet.Data.Entities.Identity;

public class UserRefreshToken
{
    public int Id { get; set; }
    public string AppUserId { get; set; }
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public string? JwtId { get; set; }
    public bool IsUsed { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime AddedTime { get; set; }
    public DateTime ExpiryDate { get; set; }
    public virtual Employee? user { get; set; }
}