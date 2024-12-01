/// <reference path="../.astro/types.d.ts" />
interface ImportMetaEnv {
    readonly EMAIL_USERNAME: string;
    readonly EMAIL_PASSWORD: string;
  }
  
  interface ImportMeta {
    readonly env: ImportMetaEnv;
  }