export const environment = {
  production: false,
  apiUrl: (window as CustomWindow).env?.API_URL ?? 'https://localhost:7048/api',
  // apiUrl: (window as CustomWindow).env?.API_URL ?? 'https://api-dev.boilerplate.ai/api',
  nodeEnv: (window as CustomWindow).env?.NODE_ENV ?? 'development'
};

export type CustomWindow = Window & typeof globalThis & {
  env: {
    API_URL?: string;
    NODE_ENV?: string;
  };
}
