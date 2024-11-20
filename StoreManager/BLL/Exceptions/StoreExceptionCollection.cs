namespace StoreManager.BLL.Exceptions;

public class UnavailableProductsInStoreException(string message) : Exception(message);

public class InsufficientProductsInStoreException(string message) : Exception(message);

public class ProductCombinationUnavailableException(string message): Exception(message);