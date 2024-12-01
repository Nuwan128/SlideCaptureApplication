import { defineConfig } from 'astro/config';
import mdx from '@astrojs/mdx';
import sitemap from '@astrojs/sitemap';
import node from '@astrojs/node'; // Ensure this is included

export default defineConfig({
  site: 'https://example.com',
  output: 'server',
  integrations: [
    mdx(),
    sitemap(),
    node({ mode: 'standalone' }),
  ],
});
