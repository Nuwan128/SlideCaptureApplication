import type { APIRoute } from 'astro';
import nodemailer from 'nodemailer';

export const post: APIRoute = async ({ request }) => {
    console.log('API handler invoked');
    try {
        const { name, email, message } = await request.json();
        if (!name || !email || !message) {
            return new Response('Invalid input', { status: 400 });
        }

        const transporter = nodemailer.createTransport({
            service: 'gmail',
            auth: {
                user: process.env.EMAIL_USERNAME,
                pass: process.env.EMAIL_PASSWORD,
            },
        });

        const mailOptions = {
            from: process.env.EMAIL_USERNAME,
            to: 'nuwan.pradeep.dev@gmail.com',
            subject: `New Message from ${name}`,
            html: `<b>Name:</b> ${name}<br><b>Email:</b> ${email}<br><b>Message:</b><p>${message}</p>`,
        };

        await transporter.sendMail(mailOptions);
        return new Response('Message sent successfully!', { status: 200 });
    } catch (error) {
        console.error('Error sending email:', error);
        return new Response('Failed to send email.', { status: 500 });
    }
};
