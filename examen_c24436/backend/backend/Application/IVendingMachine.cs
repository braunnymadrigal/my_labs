﻿using backend.Domain;

namespace backend.Application
{
    public interface IVendingMachine
    {
        List<ItemModel> getItems();
    }
}
