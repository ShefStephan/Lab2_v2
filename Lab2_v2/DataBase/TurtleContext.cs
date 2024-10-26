﻿using Lab1_v2.TurtleObject;

namespace Lab1_v2.DataBase;
using Microsoft.EntityFrameworkCore;

public class TurtleContext: DbContext
{
    public DbSet<TurtleStatus> TurtleStatus { get; set; } = null!;
    public DbSet<TurtleCoords> TurtleCoords { get; set; } = null!;
    public DbSet<Command> Command {get;set; } = null!;
    public DbSet<Figure> Figure {get;set; } = null!;
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=mydb.db");
    }
    
    
    
    public void InitializeDatabase()
    {
        using (var context = new TurtleContext())
        {
            // Проверяем, есть ли записи в таблице TurtleStatus
            if (!context.TurtleStatus.Any())
            {
                var initialStatus = new TurtleStatus
                {
                    Xcoors = 0,           // начальная координата X
                    Ycoors = 0,           // начальная координата Y
                    PenCondition = "down",   // начальное состояние пера
                    Angle = 0,            // начальный угол поворота
                    Color = "black",      // начальный цвет
                    Width = 1             // начальная ширина пера
                };

                context.TurtleStatus.Add(initialStatus);
            }

            // Проверяем, есть ли записи в таблице TurtleCoords
            if (!context.TurtleCoords.Any())
            {
                var initialCoords = new TurtleCoords
                {
                    xCoord = 0,           // начальная координата X
                    yCoord = 0            // начальная координата Y
                };

                context.TurtleCoords.Add(initialCoords);
            }

            context.SaveChanges();
        }
    }

}