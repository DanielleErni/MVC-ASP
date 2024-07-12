using Microsoft.EntityFrameworkCore;
using SeamenResto.Models;

namespace SeamenResto.Data;

public class RestoDb : DbContext
{
    public RestoDb(DbContextOptions<RestoDb> options): base(options){

    }
    
    public DbSet<OrderEntity> Orders {get; set;} 
}
