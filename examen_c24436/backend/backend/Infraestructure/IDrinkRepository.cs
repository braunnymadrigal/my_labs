﻿using backend.Domain;

namespace backend.Infraestructure
{
    public interface IDrinkRepository
    {
        List<ItemModel> getDrinks();
    }
}
