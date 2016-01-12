﻿using System.Threading;
using System.Threading.Tasks;

namespace Merq
{
	/// <summary>
	/// Provides a uniform way of executing commands regardless of their 
	/// providers.
	/// </summary>
	public interface ICommandBus : IFluentInterface
	{
		/// <summary>
		/// Determines whether the given command type has a registered handler.
		/// </summary>
		/// <typeparam name="TCommand">The type of command to query.</typeparam>
		/// <returns><see langword="true"/> if the command has a registered handler. <see langword="false"/> otherwise.</returns>
		bool CanHandle<TCommand>() where TCommand : IExecutable;

		/// <summary>
		/// Determines whether the given command has a registered handler.
		/// </summary>
		/// <param name="command">The command to query.</param>
		/// <returns><see langword="true"/> if the command has a registered handler. <see langword="false"/> otherwise.</returns>
		bool CanHandle (IExecutable command);

		/// <summary>
		/// Determines whether the given command can be executed by a registered 
		/// handler with the provided command instance values.
		/// </summary>
		/// <param name="command">The command parameters for the query.</param>
		/// <returns><see langword="true"/> if the command can be executed. <see langword="false"/> otherwise.</returns>
		bool CanExecute (IExecutable command);

		/// <summary>
		/// Executes the given synchronous command.
		/// </summary>
		/// <param name="command">The command parameters for the execution.</param>
		void Execute (ICommand command);

		/// <summary>
		/// Executes the given synchronous command and returns a result from it.
		/// </summary>
		/// <typeparam name="TResult">The return type of the command execution.</typeparam>
		/// <param name="command">The command parameters for the execution.</param>
		/// <returns>The result of executing the command.</returns>
		TResult Execute<TResult>(ICommand<TResult> command);

		/// <summary>
		/// Executes the given asynchronous command.
		/// </summary>
		/// <param name="command">The command parameters for the execution.</param>
		/// <param name="cancellation">Cancellation token to cancel command execution.</param>
		Task ExecuteAsync (IAsyncCommand command, CancellationToken cancellation);

		/// <summary>
		/// Executes the given asynchronous command and returns a result from it.
		/// </summary>
		/// <typeparam name="TResult">The return type of the command execution.</typeparam>
		/// <param name="command">The command parameters for the execution.</param>
		/// <param name="cancellation">Cancellation token to cancel command execution.</param>
		/// <returns>The result of executing the command.</returns>
		Task<TResult> ExecuteAsync<TResult>(IAsyncCommand<TResult> command, CancellationToken cancellation);
	}
}
