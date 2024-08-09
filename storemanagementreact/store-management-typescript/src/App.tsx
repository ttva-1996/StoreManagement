// src/App.tsx
import React, { Component } from 'react';

interface AppProps {
  title: string;
}

interface AppState {
  counter: number;
}

class App extends Component<AppProps, AppState> {
  constructor(props: AppProps) {
    super(props);
    this.state = {
      counter: 0,
    };
  }

  incrementCounter = () => {
    this.setState({ counter: this.state.counter + 1 });
  };

  render() {
    return (
      <div className="App">
        <header className="App-header">
          <h1>{this.props.title}</h1>
          <p>Counter: {this.state.counter}</p>
          <button onClick={this.incrementCounter}>Increment</button>
        </header>
      </div>
    );
  }
}

export default App;
