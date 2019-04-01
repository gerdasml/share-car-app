import * as React from "react";
import Modal from 'react-responsive-modal';
import "../styles/genericStyles.css"
export class GDPRAgreement extends React.Component<>{
    state = {
        open: false
    }

    onOpenModal = () => {
        this.setState({ open: true });
    };

    onCloseModal = () => {
        this.setState({ open: false });
    };

    handleCheck = () => {
        this.props.checkBoxClick();
    };

    render() {
        const { open } = this.state;
        return (
            <div>

                <div>
                    <input type="checkbox" onChange={this.handleCheck} defaultChecked={false} />

                   <span> I agree that my personal and Cognizant email will be saved. </span><a className="read-more" onClick={this.onOpenModal}>Read More.</a>
                </div>
                <Modal open={open} onClose={this.onCloseModal} center>
                <h1>Privacy Policy</h1>


<p>Effective date: April 01, 2019</p>


<p>Share car app ("us", "we", or "our") operates the ShareCar.com website (the "Service").</p>

<p>This page informs you of our policies regarding the collection, use, and disclosure of personal data when you use our Service and the choices you have associated with that data.</p>

<p>We use your data to provide and improve the Service. By using the Service, you agree to the collection and use of information in accordance with this policy. Unless otherwise defined in this Privacy Policy, terms used in this Privacy Policy have the same meanings as in our Terms and Conditions, accessible from ShareCar.com</p>


<h2>Information Collection And Use</h2>

<p>We collect several different types of information for various purposes to provide and improve our Service to you.</p>

<h3>Types of Data Collected</h3>

<h4>Personal Data</h4>

<p>While using our Service, we may ask you to provide us with certain personally identifiable information that can be used to contact or identify you ("Personal Data"). Personally identifiable information may include, but is not limited to:</p>

<ul>
<li>Email address</li><li>First name and last name</li><li>Phone number</li><li>Cookies and Usage Data</li>
</ul>


<h4>Tracking & Cookies Data</h4>
<p>We use cookies and similar tracking technologies to track the activity on our Service and hold certain information.</p>
<p>Cookies are files with small amount of data which may include an anonymous unique identifier. Cookies are sent to your browser from a website and stored on your device.</p>
<p>You can instruct your browser to refuse all cookies or to indicate when a cookie is being sent. However, if you do not accept cookies, you may not be able to use some portions of our Service.</p>
<p>Examples of Cookies we use:</p>
<ul>
    <li><strong>Session Cookies.</strong> We use Session Cookies to operate our Service.</li>
    <li><strong>Security Cookies.</strong> We use Security Cookies for security purposes.</li>
</ul>

<h2>Use of Data</h2>
    
<p>Share car app uses the collected data for various purposes:</p>    
<ul>
    <li>To provide and maintain the Service</li>
    <li>To notify you about changes to our Service</li>
    <li>To allow you to participate in interactive features of our Service when you choose to do so</li>
    <li>To provide customer care and support</li>
    <li>To provide analysis or valuable information so that we can improve the Service</li>
    <li>To monitor the usage of the Service</li>
    <li>To detect, prevent and address technical issues</li>
</ul>

<h2>Transfer Of Data</h2>
<p>Your information, including Personal Data, may be transferred to — and maintained on — computers located outside of your state, province, country or other governmental jurisdiction where the data protection laws may differ than those from your jurisdiction.</p>
<p>If you are located outside Lithuania and choose to provide information to us, please note that we transfer the data, including Personal Data, to Lithuania and process it there.</p>
<p>Your consent to this Privacy Policy followed by your submission of such information represents your agreement to that transfer.</p>
<p>Share car app will take all steps reasonably necessary to ensure that your data is treated securely and in accordance with this Privacy Policy and no transfer of your Personal Data will take place to an organization or a country unless there are adequate controls in place including the security of your data and other personal information.</p>

<h2>Disclosure Of Data</h2>

<h3>Legal Requirements</h3>
<p>Share car app may disclose your Personal Data in the good faith belief that such action is necessary to:</p>
<ul>
    <li>To comply with a legal obligation</li>
    <li>To protect and defend the rights or property of Share car app</li>
    <li>To prevent or investigate possible wrongdoing in connection with the Service</li>
    <li>To protect the personal safety of users of the Service or the public</li>
    <li>To protect against legal liability</li>
</ul>

<h2>Security Of Data</h2>
<p>The security of your data is important to us, but remember that no method of transmission over the Internet, or method of electronic storage is 100% secure. While we strive to use commercially acceptable means to protect your Personal Data, we cannot guarantee its absolute security.</p>

<h2>Service Providers</h2>
<p>We may employ third party companies and individuals to facilitate our Service ("Service Providers"), to provide the Service on our behalf, to perform Service-related services or to assist us in analyzing how our Service is used.</p>
<p>These third parties have access to your Personal Data only to perform these tasks on our behalf and are obligated not to disclose or use it for any other purpose.</p>


<h2>Changes To This Privacy Policy</h2>
<p>We may update our Privacy Policy from time to time. We will notify you of any changes by posting the new Privacy Policy on this page.</p>
<p>We will let you know via email and/or a prominent notice on our Service, prior to the change becoming effective and update the "effective date" at the top of this Privacy Policy.</p>
<p>You are advised to review this Privacy Policy periodically for any changes. Changes to this Privacy Policy are effective when they are posted on this page.</p>


<h2>Contact Us</h2>
<p>If you have any questions about this Privacy Policy, please contact us:</p>
<ul>
        <li>By email: share.car@cognizant.com</li>
          
        </ul>
                </Modal>
            </div>

        );
    }
}
export default GDPRAgreement;