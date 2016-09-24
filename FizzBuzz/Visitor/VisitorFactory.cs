using System;
using JetBrains.Annotations;

namespace FizzBuzz.Visitor
{
  /// <summary>
  ///   This abstract class provides the baseline to design generic dynamic visitor factories. These concrete visitors
  ///   must implement a Visit method that accepts an argument of the type to visit and produce a result of the
  ///   type of object to create.
  /// </summary>
  /// <seealso cref="VisitableExtensions.Accept{TResult}(IVisitableExtensionPoint{object}, VisitorFactory)" />
  /// <seealso cref="VisitableExtensions.Accept{TResult}(IVisitableExtensionPoint{object}, VisitorFactory, object)" />
  /// <remarks>
  ///   The code from this class was inspired by the
  ///   <a href="http://www.codeproject.com/Articles/112944/Polymorphic-Extension-Visitor-with-C">
  ///     polymorphic extension
  ///     visitor
  ///   </a>
  ///   .
  /// </remarks>
  public abstract class VisitorFactory
  {
    /// <summary>
    ///   Creates the visitor factory.
    /// </summary>
    /// <param name="rethrow">
    ///   True, if an exception should be thrown when no matching Visit method is found;
    ///   false, if a default object should be returned when no matching Visit method is found.
    /// </param>
    protected VisitorFactory(bool rethrow = false)
    {
      Rethrow = rethrow;
    }

    /// <summary>
    ///   Controls if a missing Visit method throws an exception (true) or if it executes the default fallback mechanism
    ///   and returns a default object (false).
    /// </summary>
    public bool Rethrow { get; private set; }

    /// <summary>
    ///   This method is used to create fallback objects should the visitor fail to provide a valid Visit method. It
    ///   is automatically invoked by the
    ///   <see cref="VisitableExtensions.Accept{TResult}(IVisitableExtensionPoint{object}, VisitorFactory)" />
    ///   method whenever an exception is caught for a visitor factory that does not rethrow exceptions.
    /// </summary>
    /// <typeparam name="T">The type of fallback object to create.</typeparam>
    /// <param name="visitable">The visitable object for which no valid Visit method was provided.</param>
    /// <param name="exception">The exception caught as part of the visitation process.</param>
    /// <returns>
    ///   If the factory is set to rethrow exceptions, this method will rethrow <paramref name="exception" />.
    ///   Otherwise, this method returns the default <typeparamref name="T" />.
    /// </returns>
    /// <remarks>
    ///   This method can be overridden to wrap the caught exception in other, more significant objects or if
    ///   a non default fallback object should be created. Keep in mind, however, that given that this method is generic,
    ///   non default fallback objects are likely to be created through reflection.
    /// </remarks>
    public virtual T CreateFallbackObject<T>(object visitable, Exception exception)
    {
      return default(T);
    }

    /// <summary>
    ///   This method is used to create fallback objects should the visitor fail to provide a valid Visit method. It
    ///   is automatically invoked by the
    ///   <see cref="VisitableExtensions.Accept{TResult}(IVisitableExtensionPoint{object}, VisitorFactory, object)" />
    ///   method whenever an exception is caught for a visitor factory that does not rethrow exceptions.
    /// </summary>
    /// <typeparam name="T">The type of fallback object to create.</typeparam>
    /// <param name="visitable">The visitable object for which no valid Visit method was provided.</param>
    /// <param name="exception">The exception caught as part of the visitation process.</param>
    /// <param name="parameter1">The first parameter sent to the Visit method.</param>
    /// <returns>
    ///   If the factory is set to rethrow exceptions, this method will rethrow <paramref name="exception" />.
    ///   Otherwise, this method returns the default <typeparamref name="T" />.
    /// </returns>
    /// <remarks>
    ///   This method can be overridden to wrap the caught exception in other, more significant objects or if
    ///   a non default fallback object should be created. Keep in mind, however, that given that this method is generic,
    ///   non default fallback objects are likely to be created through reflection.
    /// </remarks>
    [UsedImplicitly]
    public virtual T CreateFallbackObject<T>(object visitable, Exception exception, object parameter1)
    {
      return CreateFallbackObject<T>(visitable, exception);
    }

    /// <summary>
    ///   This method is used to create fallback objects should the visitor fail to provide a valid Visit method. It
    ///   is automatically invoked by the
    ///   <see cref="VisitableExtensions.Accept{TResult}(IVisitableExtensionPoint{object}, VisitorFactory, object, object)" />
    ///   method whenever an exception is caught for a visitor factory that does not rethrow exceptions.
    /// </summary>
    /// <typeparam name="T">The type of fallback object to create.</typeparam>
    /// <param name="visitable">The visitable object for which no valid Visit method was provided.</param>
    /// <param name="exception">The exception caught as part of the visitation process.</param>
    /// <param name="parameter1">The first parameter sent to the Visit method.</param>
    /// <param name="parameter2">The second parameter sent to the Visit method.</param>
    /// <returns>
    ///   If the factory is set to rethrow exceptions, this method will rethrow <paramref name="exception" />.
    ///   Otherwise, this method returns the default <typeparamref name="T" />.
    /// </returns>
    /// <remarks>
    ///   This method can be overridden to wrap the caught exception in other, more significant objects or if
    ///   a non default fallback object should be created. Keep in mind, however, that given that this method is generic,
    ///   non default fallback objects are likely to be created through reflection.
    /// </remarks>
    [UsedImplicitly]
    public virtual T CreateFallbackObject<T>(object visitable,
                                             Exception exception,
                                             object parameter1,
                                             object parameter2)
    {
      return CreateFallbackObject<T>(visitable, exception, parameter1);
    }

    /// <summary>
    ///   This method is used to create fallback objects should the visitor fail to provide a valid Visit method. It
    ///   is automatically invoked by the
    ///   <see cref="VisitableExtensions.Accept{TResult}(IVisitableExtensionPoint{object}, VisitorFactory, object, object)" />
    ///   method whenever an exception is caught for a visitor factory that does not rethrow exceptions.
    /// </summary>
    /// <typeparam name="T">The type of fallback object to create.</typeparam>
    /// <param name="visitable">The visitable object for which no valid Visit method was provided.</param>
    /// <param name="exception">The exception caught as part of the visitation process.</param>
    /// <param name="parameter1">The first parameter sent to the Visit method.</param>
    /// <param name="parameter2">The second parameter sent to the Visit method.</param>
    /// <param name="parameter3">The third parameter sent to the Visit method.</param>
    /// <returns>
    ///   If the factory is set to rethrow exceptions, this method will rethrow <paramref name="exception" />.
    ///   Otherwise, this method returns the default <typeparamref name="T" />.
    /// </returns>
    /// <remarks>
    ///   This method can be overridden to wrap the caught exception in other, more significant objects or if
    ///   a non default fallback object should be created. Keep in mind, however, that given that this method is generic,
    ///   non default fallback objects are likely to be created through reflection.
    /// </remarks>
    [UsedImplicitly]
    public virtual T CreateFallbackObject<T>(object visitable,
                                             Exception exception,
                                             object parameter1,
                                             object parameter2,
                                             object parameter3)
    {
      return CreateFallbackObject<T>(visitable, exception, parameter1, parameter2);
    }
  }

  public abstract class VisitorFactory<T> : VisitorFactory
  {
  }
}