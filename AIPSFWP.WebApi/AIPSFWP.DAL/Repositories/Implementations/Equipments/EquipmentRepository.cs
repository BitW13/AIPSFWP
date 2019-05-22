﻿using AIPSFWP.Common.Entities.Equipments;
using AIPSFWP.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AIPSFWP.DAL.Repositories.Implementations.Equipments
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ProjectContext db;

        public EquipmentRepository(ProjectContext db)
        {
            this.db = db;
        }

        public async Task<Equipment> CreateAsync(Equipment item)
        {
            if (item != null)
            {
                db.Equipments.Add(item);

                await db.SaveChangesAsync();

                return item;
            }

            return null;
        }

        public async Task<Equipment> DeleteAsync(int id)
        {
            Equipment equipment = await db.Equipments.FindAsync(id);

            if (equipment != null)
            {
                db.Equipments.Remove(equipment);

                await db.SaveChangesAsync();

                return equipment;
            }

            return null;
        }

        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await db.Equipments.ToListAsync();
        }

        public async Task<Equipment> GetItemByIdAsync(int id)
        {
            return await db.Equipments.FindAsync(id);
        }

        public async Task UpdateAsync(Equipment item)
        {
            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
