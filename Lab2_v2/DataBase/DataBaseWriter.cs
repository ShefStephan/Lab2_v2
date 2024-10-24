﻿using Lab1_v2.TurtleObject;

namespace Lab1_v2.DataBase;

public class DataBaseWriter
{
    // сохранение статуса черепашки в таблицу "TurtleStatus"
    public async Task SaveTurtleStatus(Turtle turtle)
    {
        using (var context = new TurtleContext())
        {
            var turtleStatus = new TurtleStatus
            {
                Xcoors = turtle.GetCoordX(),
                Ycoors = turtle.GetCoordY(),
                Angle = turtle.GetAngle(),
                Color = turtle.GetColor(),
                PenCondition = turtle.GetPenCondition(),
                Width = turtle.GetWidth()
            };
            
            context.TurtleStatus.Add(turtleStatus);
            await context.SaveChangesAsync();
        }
    }
    
    // сохранение команды в таблицу "Command"
    public async Task SaveCommand(string commandText)
    {
        using (var context = new TurtleContext())  
        {
            var command = new Command
            {
                CommandText = commandText,
            };

            context.Command.Add(command);
            await context.SaveChangesAsync();  // Сохраняем изменения в базу данных
        }
    }
    
    // сохранение фигуры в таблицу "Figure"
    public async Task SaveFigure(string figureType, string parameters)
    {
        using (var context = new TurtleContext())
        {
            var figure = new Figure
            {
                FigureType = figureType,
                Parameters = parameters,
            };

            context.Figure.Add(figure);
            await context.SaveChangesAsync(); // Сохраняем изменения в базу данных
        }
    }
}