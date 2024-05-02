import type { StorybookConfig } from '@storybook/nextjs';

const config: StorybookConfig = {
  // stories: ['../src/**/*.mdx','../src/**/*.stories.@(js|jsx|mjs|ts|tsx)','/src/shared/components/**/*.stories.@(js|jsx|ts|tsx)'],
  // stories: ['../src/**/*.stories.mdx','../src/**/*.stories.@(js|jsx|ts|tsx)'],
  stories: ['../src/'],
  addons: [
    '@storybook/addon-links',
    '@storybook/addon-essentials',
    '@storybook/addon-onboarding',
    '@storybook/addon-interactions',
  ],
  framework: {
    name: '@storybook/nextjs',
    options: {},
  },
  docs: {
    autodocs: true,
  },
};
export default config;
