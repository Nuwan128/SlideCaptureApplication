# Use Node.js Alpine as base
FROM node:18-alpine

# Set working directory
WORKDIR /app

# Install dependencies only when needed
COPY package*.json ./

# Install dependencies with clean npm cache
RUN npm install && npm cache clean --force

# Copy source code
COPY . .

# Build the application
RUN npm run build

# Use production node environment
ENV NODE_ENV=production

# Expose the application port
EXPOSE 3000

# Set host to allow external connections
ENV HOST=0.0.0.0

# Health check
HEALTHCHECK --interval=30s --timeout=30s --start-period=5s --retries=3 \
  CMD wget --no-verbose --tries=1 --spider http://localhost:3000/ || exit 1

# Start the application
CMD ["npm", "run", "start"]